using ESFE_AGAPE_BODEGA.API.Models.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
});

builder.Services.AddScoped<RolDAL>();
builder.Services.AddScoped<ActivoDAL>();
builder.Services.AddScoped<BodegaDAL>();
builder.Services.AddScoped<EstanteDAL>();
builder.Services.AddScoped<UsuarioDAL>();
builder.Services.AddScoped<TipoActivoDAL>();
builder.Services.AddScoped<PaqueteActivoDAL>();
builder.Services.AddScoped<AjusteInventarioDAL>();
builder.Services.AddScoped<InventarioActivoDAL>();
builder.Services.AddScoped<IngresoAtivoDAL>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
