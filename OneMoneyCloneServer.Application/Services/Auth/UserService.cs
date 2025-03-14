using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OneMoneyCloneServer.Application.Infrastructure;
using OneMoneyCloneServer.Application.Services.Auth.Errors;
using OneMoneyCloneServer.DTO.Auth;
using OneMoneyCloneServer.Models.Server;
using OneMoneyCloneServer.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OneMoneyCloneServer.Application.Services.Auth;

public class UserService : IUserService
{
	private readonly UserManager<User> _userManager;
	private readonly IConfiguration _configuration;
	private readonly ICurrencyRepository _currencyRepository;
	// TODO: Use Logger
	private readonly ILogger<UserService> _logger;
	private readonly IPasswordHashingService _passwordHasher;
	private readonly IRefreshTokenRepository _refreshTokenRepository;

	public UserService(	UserManager<User> userManager,
						IConfiguration configuration,
						ICurrencyRepository currencyRepository,
						ILogger<UserService> logger,
						IPasswordHashingService passwordHasher,
						IRefreshTokenRepository refreshTokenRepository)
	{
		_userManager = userManager;
		_configuration = configuration;
		_currencyRepository = currencyRepository;
		_logger = logger;
		_passwordHasher = passwordHasher;
		_refreshTokenRepository = refreshTokenRepository;
	}

	public async Task<InfoResult<AuthResponseDto, LoginErrors>> LoginAsync(LoginDto model)
	{
		if (model is null)
			return InfoResult<AuthResponseDto, LoginErrors>.WithInfo(LoginErrors.InvalidCredentials, "Model is null");

		if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
			return InfoResult<AuthResponseDto, LoginErrors>.WithInfo(LoginErrors.InvalidCredentials, "Email or password is empty");

		try
		{
			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user is null)
				return LoginErrors.InvalidCredentials;

			if (user.PasswordHash is null)
				return InfoResult<AuthResponseDto, LoginErrors>.WithInfo(LoginErrors.InternalError, "Contact support");

			var result = _passwordHasher.VerifyPassword(user, user.PasswordHash, model.Password);

			if (result != PasswordVerificationResult.Success)
				return LoginErrors.InvalidCredentials;

			var authResponse = GenerateAuthResponse(user);
			RefreshToken rt = new()
			{
				Token = authResponse.RefreshToken.Token,
				UserId = user.Id,
				Expires = authResponse.RefreshToken.Expires
			};
			var savedRt = await _refreshTokenRepository.CreateRefreshTokenAsync(rt);

			if (savedRt is null)
				return InfoResult<AuthResponseDto, LoginErrors>.WithInfo(LoginErrors.InternalError, "Internal error, contact support");

			return authResponse;
		}
		catch (Exception ex)
		{
			return InfoResult<AuthResponseDto, LoginErrors>.WithInfo(LoginErrors.InternalError, ex.Message);
		}
	}

	public async Task<InfoResult<AuthResponseDto, RefreshTokenErrors>> RefreshTokenAsync(StringTokenPairDto tokenPair)
	{
		try
		{
			Guid userId = ExtractUserIdFromJwt(tokenPair.Token);

			if (userId == Guid.Empty)
				return InfoResult<AuthResponseDto, RefreshTokenErrors>.WithInfo(RefreshTokenErrors.InvalidToken, "Invalid token");

			var user = await _userManager.FindByIdAsync(userId.ToString());

			if (user is null)
				return InfoResult<AuthResponseDto, RefreshTokenErrors>.WithInfo(RefreshTokenErrors.UserNotFound, "User not found");

			RefreshToken? refreshToken = await _refreshTokenRepository.GetRefreshTokenByTokenAsync(tokenPair.RefreshToken);

			if (refreshToken is null)
				return InfoResult<AuthResponseDto, RefreshTokenErrors>.WithInfo(RefreshTokenErrors.InvalidRefreshToken, "Invalid refresh token");

			if (refreshToken.UserId != userId)
				return InfoResult<AuthResponseDto, RefreshTokenErrors>.WithInfo(RefreshTokenErrors.InvalidRefreshToken, "Invalid refresh token");

			if (refreshToken.IsUsed)
				return InfoResult<AuthResponseDto, RefreshTokenErrors>.WithInfo(RefreshTokenErrors.RefreshTokenUsed);

			if (refreshToken.IsRevoked)
				return InfoResult<AuthResponseDto, RefreshTokenErrors>.WithInfo(RefreshTokenErrors.RefreshTokenRevoked);

			if (refreshToken.Expires < DateTime.UtcNow)
				return InfoResult<AuthResponseDto, RefreshTokenErrors>.WithInfo(RefreshTokenErrors.ExpiredToken, "Token expired");

			refreshToken.IsUsed = true;
			await _refreshTokenRepository.UpdateRefreshTokenAsync(refreshToken);

			var response = GenerateAuthResponse(user);

			await _refreshTokenRepository.CreateRefreshTokenAsync(new RefreshToken
			{
				Token = response.RefreshToken.Token,
				UserId = user.Id,
				Expires = response.RefreshToken.Expires
			});

			return response;
		}
		catch (Exception ex)
		{
			return InfoResult<AuthResponseDto, RefreshTokenErrors>.WithInfo(RefreshTokenErrors.InternalError, ex.Message);
		}
	}

	public async Task<InfoResult<UserDto, RegisterErrors>> RegisterAsync(RegisterDto model)
	{
		if (model == null)
			return InfoResult<UserDto, RegisterErrors>.WithInfo(RegisterErrors.InvalidData, "Invalid model");

		if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
			return InfoResult<UserDto, RegisterErrors>.WithInfo(RegisterErrors.InvalidData, "Email or password empty");

		var existingUser = await _userManager.FindByEmailAsync(model.Email);
		if (existingUser != null)
			return InfoResult<UserDto, RegisterErrors>.WithInfo(RegisterErrors.EmailAlreadyExists, "Email already exists");

		if (!await _currencyRepository.IsCurrencyExists(model.MainCurrencyId))
			return InfoResult<UserDto, RegisterErrors>.WithInfo(RegisterErrors.InvalidCurrency, "Currency not found");

		var user = new User
		{
			Email = model.Email,
			UserName = model.Email,
			MainCurrencyId = model.MainCurrencyId
		};

		var creationResult = await _userManager.CreateAsync(user, model.Password);
		if (!creationResult.Succeeded)
			return InfoResult<UserDto, RegisterErrors>.WithInfo(RegisterErrors.InternalError, string.Join(", ", creationResult.Errors.Select(e => e.Description)));

		var userDto = new UserDto
		{
			Id = user.Id,
			Email = user.Email!,
			MainCurrencyId = user.MainCurrencyId,
			CreatedAt = user.CreatedAt
		};

		return userDto;
	}

	public async Task<InfoResult<bool, LogoutErrors>> LogoutAsync(StringTokenPairDto tokenPair)
	{
		if (tokenPair is null)
			return InfoResult<bool, LogoutErrors>.WithInfo(LogoutErrors.InvalidModel, "Model is null");

		if (string.IsNullOrWhiteSpace(tokenPair.Token) || string.IsNullOrWhiteSpace(tokenPair.RefreshToken))
			return InfoResult<bool, LogoutErrors>.WithInfo(LogoutErrors.InvalidModel, "Token or refresh token is empty");

		try
		{
			var userIdFromJwt = ExtractUserIdFromJwt(tokenPair.Token);
			if (userIdFromJwt == Guid.Empty)
				return InfoResult<bool, LogoutErrors>.WithInfo(LogoutErrors.InvalidToken, "Invalid token");

			var refreshToken = await _refreshTokenRepository.GetRefreshTokenByTokenAsync(tokenPair.RefreshToken);
			if (refreshToken is null)
				return InfoResult<bool, LogoutErrors>.WithInfo(LogoutErrors.InvalidToken, "Invalid refresh token");

			if (refreshToken.UserId != userIdFromJwt)
				return InfoResult<bool, LogoutErrors>.WithInfo(LogoutErrors.InvalidToken, "Invalid tokens");

			if (refreshToken.IsUsed)
				return InfoResult<bool, LogoutErrors>.WithInfo(LogoutErrors.InvalidToken, "Invalid token");

			if (refreshToken.IsRevoked)
				return InfoResult<bool, LogoutErrors>.WithInfo(LogoutErrors.InvalidToken, "Invalid token");

			var tokens = await _refreshTokenRepository.GetValidRefreshTokensByUserIdAsync(userIdFromJwt);
			if (tokens.Count() == 0)
				return InfoResult<bool, LogoutErrors>.WithInfo(LogoutErrors.InvalidToken, "Invalid token");

			foreach (var t in tokens)
				t.IsRevoked = true;

			await _refreshTokenRepository.UpdateRefreshTokensAsync(tokens);

			return true;
		}
		catch (Exception ex)
		{
			return InfoResult<bool, LogoutErrors>.WithInfo(LogoutErrors.InternalError, ex.Message);
		}
	}

	private AuthResponseDto GenerateAuthResponse(User user)
	{
		// TODO: Move this to a separate service?
		var tokenHandler = new JwtSecurityTokenHandler();
		var issuer = _configuration["Jwt:Issuer"];
		var audience = _configuration["Jwt:Audience"];
		var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
		var claims = new[]
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Email, user.Email!)
		};

		// TODO: Fix get methods
		var accessTokenExpiration = int.Parse(_configuration["Jwt:AccessTokenExpiration"]!);
		var refreshTokenExpiration = int.Parse(_configuration["Jwt:RefreshTokenExpiration"]!);

		var token = new JwtSecurityToken(
			issuer,
			audience,
			claims,
			expires: DateTime.UtcNow.AddSeconds(accessTokenExpiration),
			signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		);
		var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

		return new AuthResponseDto
		{
			AccessToken = tokenHandler.WriteToken(token),
			RefreshToken = new ()
			{
				Token = refreshToken,
				Expires = DateTime.UtcNow.AddSeconds(refreshTokenExpiration)
			},
			User = new ()
			{
				Id = user.Id,
				Email = user.Email!,
				MainCurrencyId = user.MainCurrencyId,
				CreatedAt = user.CreatedAt
			}
		};
	}

	private Guid ExtractUserIdFromJwt(string token)
	{
		var handler = new JwtSecurityTokenHandler();

		try
		{
			var jwtToken = handler.ReadJwtToken(token);
			var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

			return userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;
		}
		catch (Exception)
		{
			return Guid.Empty;
		}
	}
}
