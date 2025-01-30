using Microsoft.AspNetCore.Identity;
using OneMoneyCloneServer.Models.Server;
using OneMoneyCloneServer.Persistence;

namespace OneMoneyCloneServer.Api;

internal static class Registrator
{
	public static void AddIdentity(this IServiceCollection services)
	{
		services.AddIdentity<User, IdentityRole<Guid>>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();
	}

	public static void AddSwagger(this WebApplication app)
	{
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
		});

		app.MapGet("/", () => Results.Redirect("/swagger"));
		app.UseDeveloperExceptionPage();
	}
}
