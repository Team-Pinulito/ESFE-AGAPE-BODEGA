using Blazored.LocalStorage;
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
    client.BaseAddress = new Uri("https://bodega.bsite.net/api/");
});

builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<BodegaService>();
builder.Services.AddScoped<AjusteInventarioService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<EstanteService>();
builder.Services.AddScoped<PaqueteActivoService>();
builder.Services.AddScoped<TipoActivoService>();
builder.Services.AddScoped<KardexActivoService>();
builder.Services.AddScoped<IngresoActivoService>();
builder.Services.AddScoped<ActivoService>();
builder.Services.AddScoped<SolicitudActivoService>();


builder.Services.AddScoped<AuthService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddTransient<AuthTokenHandler>();

builder.Services.AddHttpClient("BodegaAPI")
    .AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BodegaAPI"));

await builder.Build().RunAsync();

