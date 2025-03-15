using OneMoneyCloneServer.DTO.Auth;

namespace OneMoneyCloneClient.Application.Services.Api.Interfaces;

public interface IStorageService
{
	public Task<string?> GetAccessTokenAsync();
	public Task SetAccessTokenAsync(string token);
	public Task<RefreshTokenDto?> GetRefreshTokenAsync();
	public Task SetRefreshTokenAsync(RefreshTokenDto token);
	public Task<UserDto?> GetUserAsync();
	public Task SetUserAsync(UserDto user);
	public Task RemoveAllAsync();
}
