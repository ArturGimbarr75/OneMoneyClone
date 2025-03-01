using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using System.Net.Http.Headers;

namespace OneMoneyCloneClient.Blazor;

internal class HttpClientService : IHttpClientService
{
	private readonly IHttpClientFactory _httpClientFactory;

	public HttpClientService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public HttpClient CreateClient()
	{
		var client = _httpClientFactory.CreateClient("ApiClient");
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		return client;
	}
}
