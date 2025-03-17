using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OneMoneyCloneClient.Application.Services.Api.Handlers;
using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using OneMoneyCloneClient.Blazor;
using System.Net.Http.Headers;

internal static class Registrator
{
	public static void Register(this IServiceCollection services, WebAssemblyHostConfiguration configuration)
	{
		string apiBaseUrl = configuration["OneMoneyCloneApi"]!;
		services.AddScoped<ApiAuthorizationHandler>();
		services.AddHttpClient<IHttpClientService, HttpClientService>(client =>
		{
			client.BaseAddress = new Uri(apiBaseUrl);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		})
		.AddHttpMessageHandler<ApiAuthorizationHandler>();
	}
}
