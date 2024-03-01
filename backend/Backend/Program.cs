using Backend.Database;
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


var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(option => option.EnableTryItOutByDefault());
app.UseCors("Academia2024");
app.MapCarter();


app.Run();

