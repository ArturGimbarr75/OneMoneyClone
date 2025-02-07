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
	private readonly IPasswordHashingService _passwordHasher;
	private readonly IRefreshTokenRepository _refreshTokenRepository;
	private readonly IConfiguration _configuration;
	private readonly ILogger<UserService> _logger;

	public UserService(	UserManager<User> userManager,
						IPasswordHashingService passwordHasher,
						IConfiguration configuration,
						ILogger<UserService> logger,
						IRefreshTokenRepository refreshTokenRepository)
	{
		_userManager = userManager;
		_passwordHasher = passwordHasher;
		_configuration = configuration;
		_logger = logger;
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
			await _refreshTokenRepository.CreateRefreshTokenAsync(new RefreshToken
			{
				Token = authResponse.RefreshToken.Token,
				UserId = user.Id,
				Expires = authResponse.RefreshToken.Expires
			});

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

			return GenerateAuthResponse(user);
		}
		catch (Exception ex)
		{
			return InfoResult<AuthResponseDto, RefreshTokenErrors>.WithInfo(RefreshTokenErrors.InternalError, ex.Message);
		}
	}

	public Task<InfoResult<AuthResponseDto, RegisterErrors>> RegisterAsync(RegisterDto model)
	{
		throw new NotImplementedException();
	}

	private AuthResponseDto GenerateAuthResponse(User user)
	{
		// TODO: Move this to a separate service?
		// TODO: Use  "Issuer" and "Audience"
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
		var claims = new[]
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Email, user.Email!)
		};

		// TODO: Fix get methods
		var accessTokenExpiration = int.Parse(_configuration["Jwt:AccessTokenExpiration"]!);
		var refreshTokenExpiration = int.Parse(_configuration["Jwt:RefreshTokenExpiration"]!);

		var tokenDescriptor = new SecurityTokenDescriptor()
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.UtcNow.AddSeconds(accessTokenExpiration),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
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
