using Microsoft.AspNetCore.Components.Authorization;
using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using System.Security.Claims;

namespace OneMoneyCloneClient.Application.Services;

internal class CustomAuthStateProvider : AuthenticationStateProvider
{
	private readonly IStorageService _storage;

	public CustomAuthStateProvider(IStorageService storage)
	{
		_storage = storage;
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		var token = await _storage.GetAccessTokenAsync();

		if (string.IsNullOrEmpty(token) || TokenExpired(token))
		{
			return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
		}

		var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
		var user = new ClaimsPrincipal(identity);

		return new AuthenticationState(user);
	}

	public async Task MarkUserAsAuthenticated(string token)
	{
		await _storage.SetAccessTokenAsync(token);

		var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
		var user = new ClaimsPrincipal(identity);

		NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
	}

	public async Task MarkUserAsLoggedOut()
	{
		await _storage.RemoveAllAsync();
		var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());

		NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
	}

	private static bool TokenExpired(string token)
	{
		var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
		var jwtToken = handler.ReadJwtToken(token);
		return jwtToken.ValidTo < DateTime.UtcNow;
	}

	private static IEnumerable<Claim> ParseClaimsFromJwt(string token)
	{
		var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
		var jwtToken = handler.ReadJwtToken(token);
		return jwtToken.Claims;
	}
}
