using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OneMoneyCloneServer.Persistence;
public static class Registrator
{
	public static void AddDatabase(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseMySQL(connectionString);
		});
	}
}
