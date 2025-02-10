using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OneMoneyCloneServer.Persistence;
public static class Registrator
{
	public static void AddDatabase(this IServiceCollection services, string connectionString)
	{
		var serverVersion = new MySqlServerVersion(new Version(9, 1, 0));

		services.AddDbContext<ApplicationDbContext>(
			dbContextOptions => dbContextOptions
				.UseMySql(connectionString, serverVersion)
				.EnableSensitiveDataLogging()
				.EnableDetailedErrors()
		);
	}
}
