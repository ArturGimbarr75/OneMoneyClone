using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using OneMoneyCloneServer.DTO.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace OneMoneyCloneClient.Application.Services.Api.Handlers;

public class ApiAuthorizationHandler : DelegatingHandler
{
	private readonly IStorageService _storage;
	private readonly HttpClient _httpClient;

	public ApiAuthorizationHandler(IStorageService storage, HttpClient httpClient)
	{
		_storage = storage;
		_httpClient = httpClient;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var accessToken = await _storage.GetAccessTokenAsync();

		if (string.IsNullOrEmpty(accessToken) || TokenExpired(accessToken))
		{
			var refreshToken = await _storage.GetRefreshTokenAsync();
			if (!string.IsNullOrEmpty(refreshToken?.Token))
			{
				var newAccessToken = await RefreshTokenAsync(refreshToken);
				if (!string.IsNullOrEmpty(newAccessToken))
				{
					accessToken = newAccessToken;
				}
			}
		}

		if (!string.IsNullOrEmpty(accessToken))
		{
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
		}

		return await base.SendAsync(request, cancellationToken);
	}

	private bool TokenExpired(string token)
	{
		var handler = new JwtSecurityTokenHandler();
		var jwtToken = handler.ReadJwtToken(token);
		return jwtToken.ValidTo < DateTime.UtcNow.AddMinutes(1);
	}

	private async Task<string?> RefreshTokenAsync(RefreshTokenDto refreshToken)
	{
		var response = await _httpClient.PostAsJsonAsync("api/auth/refresh", refreshToken);

		if (response.IsSuccessStatusCode)
		{
			var content = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
			if (content != null)
			{
				await _storage.SetAccessTokenAsync(content.AccessToken);
				await _storage.SetRefreshTokenAsync(content.RefreshToken);
				await _storage.SetUserAsync(content.User);

				return content.AccessToken;
			}
		}

		return null;
	}
}