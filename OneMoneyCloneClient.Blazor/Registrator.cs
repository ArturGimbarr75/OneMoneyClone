using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using OneMoneyCloneClient.Blazor;
using System.Net.Http.Headers;

internal static class Registrator
{
	public static void Register(this IServiceCollection services)
	{
		services.AddHttpClient("ApiClient", client =>
		{
			client.BaseAddress = new Uri("http://localhost:5218");
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		});
		services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiClient"));
		services.AddScoped<IHttpClientService, HttpClientService>();
	}
}
