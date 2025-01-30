using Microsoft.AspNetCore.Identity;
using OneMoneyCloneServer.Models.Server;
using OneMoneyCloneServer.Persistence;
using OneMoneyCloneServer.Repositories.Interfaces;

namespace OneMoneyCloneServer.Repositories.EF;

internal class UserRepository : IUserRepository
{
	private readonly UserManager<User> _userManager;

	public UserRepository(UserManager<User> userManager)
	{
		_userManager = userManager;
	}

	public async Task<User?> GetUserByIdAsync(Guid id)
	{
		return await _userManager.FindByIdAsync(id.ToString());
	}

	public async Task<User?> GetUserByEmailAsync(string email)
	{
		return await _userManager.FindByEmailAsync(email);
	}

	public async Task<IdentityResult> CreateUserAsync(User user, string password)
	{
		return await _userManager.CreateAsync(user, password);
	}

	public async Task<IdentityResult> UpdateUserAsync(User user)
	{
		return await _userManager.UpdateAsync(user);
	}

	public async Task<IdentityResult> DeleteUserAsync(Guid id)
	{
		var user = await _userManager.FindByIdAsync(id.ToString());
		if (user is null)
			return IdentityResult.Failed(new IdentityError { Description = "User not found" });

		return await _userManager.DeleteAsync(user);
	}
}
