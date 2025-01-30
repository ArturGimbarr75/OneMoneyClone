using Microsoft.Extensions.DependencyInjection;
using OneMoneyCloneServer.Repositories.EF;
using OneMoneyCloneServer.Repositories.Interfaces;

namespace OneMoneyCloneServer.Repositories;

public static class Registrator
{
	public static void RegisterRepositories(IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();
	}
}
