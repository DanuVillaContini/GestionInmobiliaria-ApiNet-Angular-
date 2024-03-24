using Backend.Database;
using Backend.Repository;
using Backend.Service;
using Carter;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Para MAPPERS
TypeAdapterConfig.GlobalSettings.Scan(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

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

//Auth Jwt
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });

var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(option => option.EnableTryItOutByDefault());
app.UseCors("Academia2024");
app.MapCarter();


app.Run();

