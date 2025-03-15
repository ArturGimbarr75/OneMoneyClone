using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using System.Net.Http.Headers;

namespace OneMoneyCloneClient.Blazor;

internal class HttpClientService : IHttpClientService
{
	private readonly HttpClient _httpClient;

	public HttpClientService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public HttpClient CreateClient()
	{
		_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		return _httpClient;
	}
}
