using Blazored.LocalStorage;
using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using OneMoneyCloneServer.DTO.Auth;

namespace OneMoneyCloneClient.Application.Services.Api;
internal class StorageService : IStorageService
{
	private readonly ILocalStorageService _localStorage;

	private const string ACCESS_TOKEN_KEY = "access_token";
	private const string REFRESH_TOKEN_KEY = "refresh_token";
	private const string USER_KEY = "user";

	public StorageService(ILocalStorageService localStorage)
	{
		_localStorage = localStorage;
	}

	public async Task<string?> GetAccessTokenAsync()
	{
		return await _localStorage.GetItemAsync<string>(ACCESS_TOKEN_KEY);
	}

	public async Task SetAccessTokenAsync(string token)
	{
		await _localStorage.SetItemAsync(ACCESS_TOKEN_KEY, token);
	}

	public async Task<RefreshTokenDto?> GetRefreshTokenAsync()
	{
		return await _localStorage.GetItemAsync<RefreshTokenDto>(REFRESH_TOKEN_KEY);
	}

	public async Task SetRefreshTokenAsync(RefreshTokenDto token)
	{
		await _localStorage.SetItemAsync(REFRESH_TOKEN_KEY, token);
	}

	public async Task<UserDto?> GetUserAsync()
	{
		return await _localStorage.GetItemAsync<UserDto>(USER_KEY);
	}

	public async Task SetUserAsync(UserDto user)
	{
		await _localStorage.SetItemAsync(USER_KEY, user);
	}

	public async Task RemoveAllAsync()
	{
		await _localStorage.ClearAsync();
	}
}
