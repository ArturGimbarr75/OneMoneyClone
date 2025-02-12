using Microsoft.AspNetCore.Identity;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Application.Services.Auth;

public interface IPasswordHashingService
{
	string HashPassword(User user, string password);
	PasswordVerificationResult VerifyPassword(User user, string hashedPassword, string providedPassword);
}
