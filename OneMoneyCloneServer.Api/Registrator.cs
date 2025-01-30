using Microsoft.AspNetCore.Identity;
using OneMoneyCloneServer.Models.Server;
using OneMoneyCloneServer.Persistence;

namespace OneMoneyCloneServer.Api;

internal static class Registrator
{
	public static void RegisterIdentity(IServiceCollection services)
	{
		services.AddIdentity<User, IdentityRole<Guid>>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();
	}
}
