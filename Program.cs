using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBooksStore.Services.Interfaces;
using BlazorBooksStore.Services;
using BlazorBooksStore;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["ApiUrl"];
if (string.IsNullOrWhiteSpace(apiUrl))
{
	throw new InvalidOperationException("ApiUrl configuration is missing or empty.");
}
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

// Register for new services
builder.Services.AddScoped<ILoggingService, ConsoleLoggingService>();
builder.Services.AddScoped<IBooksService, LocalBooksService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton<AppStateContainer>();

await builder.Build().RunAsync();
