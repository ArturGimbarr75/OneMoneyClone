using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OneMoneyCloneClient.Application;
using OneMoneyCloneClient.Application.Services.Api.Interfaces;
using OneMoneyCloneClient.Blazor;
using OneMoneyCloneServer.DTO.Auth;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.Register();
builder.Services.AddServices();

await builder.Build().RunAsync();
