using Microsoft.AspNetCore.Components;
using OneMoneyCloneClient.Application.Services;
using OneMoneyCloneClient.Application.Services.Api.Interfaces;

namespace OneMoneyCloneClient.Blazor.Layout;
public partial class MainLayout
{
	private readonly CustomAuthStateProvider _stateProvider;
	private readonly IAuthService _authService;
	private readonly NavigationManager _navigationManager;

	public MainLayout(CustomAuthStateProvider stateProvider, IAuthService authService, NavigationManager navigationManager)
	{
		_stateProvider = stateProvider;
		_authService = authService;
		_navigationManager = navigationManager;
	}

	private async Task Logout()
	{
		await _stateProvider.MarkUserAsLoggedOut();
		_navigationManager.NavigateTo("/");
	}

	private async Task LogoutFromAllDevices()
	{
		await _authService.LogoutFromAllDevicesAsync();
		await _stateProvider.MarkUserAsLoggedOut();
		_navigationManager.NavigateTo("/");
	}
}