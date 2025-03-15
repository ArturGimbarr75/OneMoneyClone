using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OneMoneyCloneServer.Api;
using OneMoneyCloneServer.Application;
using OneMoneyCloneServer.Persistence;
using OneMoneyCloneServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwagger();
builder.Services.AddControllers();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddOpenApi();
builder.Services.AddHttpLogging(o => { });

string connectionString = builder.Configuration.GetConnectionString("DebugConnection")!;
builder.Services.AddDatabase(connectionString);
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddIdentity();
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddCorsPolicy();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.AddSwagger();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpLogging();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
	await db.Database.MigrateAsync();
}

app.Run();
