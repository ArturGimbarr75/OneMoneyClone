using Microsoft.AspNetCore.Identity;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Application.Services.Auth;

public class PasswordHashingService : IPasswordHashingService
{
	private readonly IPasswordHasher<User> _passwordHasher;

	public PasswordHashingService(IPasswordHasher<User> passwordHasher)
	{
		_passwordHasher = passwordHasher;
	}

	public string HashPassword(User user, string password)
	{
		return _passwordHasher.HashPassword(user, password);
	}

	public PasswordVerificationResult VerifyPassword(User user, string hashedPassword, string providedPassword)
	{
		return _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
	}
}