using ESFE_AGAPE_BODEGA.BlazorWebAssembly;
using ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("BodegaAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7214/api/");
});

builder.Services.AddScoped<RolService>();

await builder.Build().RunAsync();
