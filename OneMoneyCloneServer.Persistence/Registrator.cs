using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OneMoneyCloneServer.Persistence;
public static class Registrator
{
	public static void RegisterDatabase(IServiceCollection services, string connectionString)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseMySQL(connectionString);
		});
	}
}
