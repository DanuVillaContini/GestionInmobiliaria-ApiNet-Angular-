using Backend.Database;
using Backend.Repository;
using Backend.Service;
using Carter;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Para MAPPERS
TypeAdapterConfig.GlobalSettings.Scan(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;

builder.Services.AddCarter();
builder.Services.AddCors(options => options.AddPolicy("Academia2024",
    policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(config.GetConnectionString("AppDb")));

//PRODUCTO INYECTADO:
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

//ESTADO-PRODUCTO INYECTADO:
builder.Services.AddTransient<IEstadoProductoRepository, EstadoProductoRepository>();
builder.Services.AddScoped<IEstadoProductoService, EstadoProductoService>();

////ESTADO-PRODUCTO INYECTADO:
builder.Services.AddTransient<IEstadoReservaRepository, EstadoReservaRepository>();
builder.Services.AddScoped<IEstadoReservaService, EstadoReservaService>();

////RESERVAS INYECTADO:
builder.Services.AddTransient<IReservaRepository, ReservaRespository>();
builder.Services.AddScoped<IReservaService, ReservaService>();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(option => option.EnableTryItOutByDefault());
app.UseCors("Academia2024");
app.MapCarter();


app.Run();

