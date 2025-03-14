using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using System.Security.Claims;

namespace OneMoneyCloneClient.Application.Services;

internal class CustomAuthStateProvider : AuthenticationStateProvider, IDisposable
{
	private readonly IStorageService _storage;
	private readonly NavigationManager _navigation;
	private EventHandler<LocationChangedEventArgs>? _locationChangedHandler;

	public CustomAuthStateProvider(IStorageService storage, NavigationManager navigation)
	{
		_storage = storage;
		_navigation = navigation;

		_locationChangedHandler = async (sender, args) => await CheckAndUpdateAuthStateAsync();
		_navigation.LocationChanged += _locationChangedHandler;
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		var token = await _storage.GetAccessTokenAsync();

		if (string.IsNullOrEmpty(token) || TokenExpired(token))
		{
			var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
			var authState = new AuthenticationState(anonymousUser);

			NotifyAuthenticationStateChanged(Task.FromResult(authState));

			return authState;
		}

		var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
		var user = new ClaimsPrincipal(identity);
		var authenticatedState = new AuthenticationState(user);

		NotifyAuthenticationStateChanged(Task.FromResult(authenticatedState));

		return authenticatedState;
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

	public void Dispose()
	{
		if (_locationChangedHandler is not null)
			_navigation.LocationChanged -= _locationChangedHandler;
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

	private async Task CheckAndUpdateAuthStateAsync()
	{
		var authState = await GetAuthenticationStateAsync();
		NotifyAuthenticationStateChanged(Task.FromResult(authState));
	}
}
