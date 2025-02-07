using Microsoft.Extensions.DependencyInjection;
using OneMoneyCloneServer.Repositories.EF;
using OneMoneyCloneServer.Repositories.Interfaces;

namespace OneMoneyCloneServer.Repositories;

public static class Registrator
{
	public static void AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<ICurrencyRepository, CurrencyRepository>();
		services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
	}
}
