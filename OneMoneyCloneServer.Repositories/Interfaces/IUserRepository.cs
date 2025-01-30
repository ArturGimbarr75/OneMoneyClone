using Microsoft.AspNetCore.Identity;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Repositories.Interfaces;

public interface IUserRepository
{
	Task<User?> GetUserByIdAsync(Guid id);
	Task<User?> GetUserByEmailAsync(string email);
	Task<IdentityResult> CreateUserAsync(User user, string password);
	Task<IdentityResult> UpdateUserAsync(User user);
	Task<IdentityResult> DeleteUserAsync(Guid id);
}