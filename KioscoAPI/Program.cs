using KioscoAPI.Models;
using KioscoAPI.Repository.Implementaciones;
using KioscoAPI.Repository.Interfaces;
using KioscoAPI.Servicios.Implementaciones;
using KioscoAPI.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddOpenApi();

//CONEXION CON LA BD
builder.Services.AddDbContext<KioscoDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//AGREGAMOS LOS SERVICIOS
builder.Services.AddScoped<IServicioArticulo, ArticuloServicio>();

//AGREGAMOS LOS REPOSITORIOS
builder.Services.AddScoped<IRepositoryArticulo, ArticuloRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
