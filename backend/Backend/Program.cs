using Backend.Database;
using Backend.Repository;
using Backend.Service;
using Carter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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
//builder.Services.AddTransient<IEstadoProductoRepository, EstadoProductoRepository>();
//builder.Services.AddScoped<IEstadoProductoService, EstadoProductoService>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(option => option.EnableTryItOutByDefault());
app.UseCors("Academia2024");
app.MapCarter();


app.Run();

