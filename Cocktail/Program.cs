using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Cocktail;
using Cocktail.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/") });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ICocktailService, CocktailService>();
builder.Services.AddScoped<IFavService, FavService>();
await builder.Build().RunAsync();