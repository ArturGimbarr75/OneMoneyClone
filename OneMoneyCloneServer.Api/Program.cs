using OneMoneyCloneServer.Api;
using OneMoneyCloneServer.Persistence;
using OneMoneyCloneServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

string connectionString = builder.Configuration.GetConnectionString("DebugConnection")!;
builder.Services.AddDatabase(connectionString);
builder.Services.AddRepositories();
builder.Services.AddIdentity();

var app = builder.Build();

if (app.Environment.IsDevelopment())
	app.AddSwagger();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
