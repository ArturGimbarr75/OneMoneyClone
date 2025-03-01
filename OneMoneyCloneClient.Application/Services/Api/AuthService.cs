using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using OneMoneyCloneServer.DTO.Auth;
using System.Net.Http.Json;

namespace OneMoneyCloneClient.Application.Services.Api;

internal class AuthService : IAuthService
{
	private readonly IHttpClientService _httpClientService;
	private readonly IStorageService _storage;

	public AuthService(IHttpClientService httpClientService, IStorageService storage)
	{
		_httpClientService = httpClientService;
		_storage = storage;
	}

	public async Task<bool> LoginAsync(LoginDto model)
	{
		try
		{
			var client = _httpClientService.CreateClient();
			var response = await client.PostAsJsonAsync("api/auth/login", model);

			if (response != null)
			{
				var content = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
			
				if (content != null)
				{
					await _storage.SetAccessTokenAsync(content.AccessToken);
					await _storage.SetRefreshTokenAsync(content.RefreshToken);
					await _storage.SetUserAsync(content.User);
				
					return response.IsSuccessStatusCode;
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		return false;
	}

	public async Task<bool> RegisterAsync(RegisterDto model)
	{
		var client = _httpClientService.CreateClient();
		var response = await client.PostAsJsonAsync("api/auth/register", model);

		if (response != null)
		{
			var content = await response.Content.ReadFromJsonAsync<UserDto>();

			if (content != null)
			{
				await _storage.SetUserAsync(content);

				return response.IsSuccessStatusCode;
			}
		}

		return false;
	}

	public async Task<bool> LogoutAsync()
	{
		await _storage.RemoveAllAsync();
		return true;
	}

	public async Task<bool> LogoutFromAllDevicesAsync()
	{
		var client = _httpClientService.CreateClient();
		var response = await client.PostAsync("api/auth/logout", null);

		if (response.IsSuccessStatusCode)
		{
			await _storage.RemoveAllAsync();
		}

		return response.IsSuccessStatusCode;
	}

	public async Task<bool> RefreshTokenAsync()
	{
		var client = _httpClientService.CreateClient();
		var response = await client.PostAsync("api/auth/refresh", null);

		if (response != null)
		{
			var content = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
			if (content != null)
			{
				await _storage.SetAccessTokenAsync(content.AccessToken);
				await _storage.SetRefreshTokenAsync(content.RefreshToken);
				await _storage.SetUserAsync(content.User);

				return response.IsSuccessStatusCode;
			}
		}

		return false;
	}
}
