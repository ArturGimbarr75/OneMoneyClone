﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OneMoneyCloneServer.Application.Infrastructure;
using OneMoneyCloneServer.Application.Services.Auth.Errors;
using OneMoneyCloneServer.DTO.Auth;
using OneMoneyCloneServer.Models.Server;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OneMoneyCloneServer.Application.Services.Auth;

public class UserService : IUserService
{
	private readonly UserManager<User> _userManager;
	private readonly IPasswordHashingService _passwordHasher;
	private readonly IConfiguration _configuration;
	private readonly ILogger _logger;

	public UserService(UserManager<User> userManager, IPasswordHashingService passwordHasher, IConfiguration configuration, ILogger logger)
	{
		_userManager = userManager;
		_passwordHasher = passwordHasher;
		_configuration = configuration;
		_logger = logger;
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

			return GenerateAuthResponse(user);
		}
		catch (Exception ex)
		{
			return InfoResult<AuthResponseDto, LoginErrors>.WithInfo(LoginErrors.Other, ex.Message);
		}
	}

	public Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto model)
	{
		throw new NotImplementedException();
	}

	public async Task<AuthResponseDto> RegisterAsync(RegisterDto model)
	{
		throw new NotImplementedException();
		/*var user = new User { Email = model.Email, UserName = model.Email, MainCurrencyId = model.MainCurrencyId };
		var result = await _userManager.CreateAsync(user, model.Password);

		if (!result.Succeeded)
			throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

		return GenerateAuthResponse(user);*/
	}

	private AuthResponseDto GenerateAuthResponse(User user)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
		var claims = new[]
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Email, user.Email!)
		};

		var tokenDescriptor = new SecurityTokenDescriptor()
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.UtcNow.AddHours(1),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

		return new AuthResponseDto
		{
			Token = tokenHandler.WriteToken(token),
			RefreshToken = refreshToken,
			User = new UserDto()
			{
				Id = user.Id,
				Email = user.Email!,
				MainCurrencyId = user.MainCurrencyId,
				CreatedAt = user.CreatedAt
			}
		};
	}
}
