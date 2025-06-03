using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http;
using BlazorBooksStore.Services.Interfaces;
using BlazorBooksStore.Services;
using BlazorBooksStore;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register for new services
builder.Services.AddScoped<ILoggingService, ConsoleLoggingService>();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<DemoLoggingHandler>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiUrl"]) });

builder.Services.AddHttpClient("BlazorBooksStore.Api", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
})
.AddHttpMessageHandler<DemoLoggingHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorBooksStore.Api"));

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtCustomAuthenticationStateProvider>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton<AppStateContainer>();

await builder.Build().RunAsync();
