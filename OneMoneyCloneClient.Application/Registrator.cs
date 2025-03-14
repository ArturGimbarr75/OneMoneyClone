using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using OneMoneyCloneClient.Application.Services;
using OneMoneyCloneClient.Application.Services.Api;
using OneMoneyCloneClient.Application.Services.Api.Interfaces;

namespace OneMoneyCloneClient.Application;

public static class Registrator
{
	public static void AddServices(this IServiceCollection services)
	{
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<IStorageService, StorageService>();
		services.AddBlazoredLocalStorage();
		services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
		services.AddScoped<CustomAuthStateProvider>();
		services.AddAuthorizationCore();
	}
}
