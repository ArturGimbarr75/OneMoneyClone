using OneMoneyCloneClient.Application.Services.Api.Handlers;
using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using OneMoneyCloneClient.Blazor;
using System.Net.Http.Headers;

internal static class Registrator
{
	public static void Register(this IServiceCollection services)
	{
		services.AddScoped<ApiAuthorizationHandler>();
		services.AddHttpClient<IHttpClientService, HttpClientService>(client =>
		{
			client.BaseAddress = new Uri("http://localhost:5218");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		})
		.AddHttpMessageHandler<ApiAuthorizationHandler>();
		services.AddScoped<IHttpClientService, HttpClientService>();
	}
}
