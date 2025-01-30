using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OneMoneyCloneServer.Application.Services.Auth;
using OneMoneyCloneServer.Models.Server;

namespace OneMoneyCloneServer.Application;

public static class Registrator
{
	public static void AddServices(this IServiceCollection services)
	{
		services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
		services.AddScoped<IPasswordHasherService, PasswordHasherService>();
	}
}
