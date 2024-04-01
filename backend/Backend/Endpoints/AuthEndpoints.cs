using Backend.Database;
using Backend.Domain;
using Backend.Endpoints.DTO;
using Carter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Backend.Endpoints;
public class AuthEndpoints(IConfiguration configuration) : ICarterModule
{
    //50:00
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Account");

        app.MapPost("/Register", (AppDbContext context, UsuarioRegisterDto request) =>
        {

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new Usuario()
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Name = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var role = context.Roles.FirstOrDefault(x => x.Name == request.Role);

            if (role is null)
            {
                return Results.BadRequest("Rol inexistente.");
            }

            user.Roles.Add(role);

            context.Usuarios.Add(user);

            context.SaveChanges();

            var userCreated = context.Usuarios.FirstOrDefault(x => x.Id == user.Id);

            return Results.Ok(new { Id = userCreated.Id, Username = userCreated.Username, Role = userCreated.Roles.First().Name });
        }).WithTags("Account")
        .AllowAnonymous(); //allow... espara que cualquier user lo pueda usar

        app.MapPost("/Login", (AppDbContext context, UsuarioDto request) =>
        {

            var user = context.Usuarios.Where(x => x.Username == request.Username).Include(x => x.Roles).First();

            if (user is null)
            {
                return Results.BadRequest("Usuario inexistente.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Results.BadRequest("Contraseña incorrecta.");
            }

            var token = new { accessToken = CreateToken(user) };

            return Results.Ok(token);
        }).WithTags("Account")
        .AllowAnonymous();

        app.MapPost("/Role", (AppDbContext context, RolDto request) =>
        {
            var role = new Rol()
            {
                Name = request.Name
            };

            context.Roles.Add(role);

            context.SaveChanges();

            return Results.Ok(role);
        }).WithTags("Account")
        .RequireAuthorization(new AuthorizeAttribute { Roles = "ADMIN" });

        app.MapPost("/User/{userId:Guid}/AddRole/{roleId:Guid}", (AppDbContext context, Guid userId, Guid roleId) => {

            var user = context.Usuarios.FirstOrDefault(x => x.Id == userId);

            if (user is null)
            {
                return Results.BadRequest("Usuario inexistente.");
            }

            var role = context.Roles.FirstOrDefault(x => x.Id == roleId);

            if (role is null)
            {
                return Results.BadRequest("Rol inexistente.");
            }

            user.Roles.Add(role);

            context.SaveChanges();

            return Results.Ok("Rol asociado");
        }).WithTags("Account")
        .RequireAuthorization(new AuthorizeAttribute { Roles = "ADMIN" });


        app.MapGet("/User", (AppDbContext context) =>
        {
            var users = context.Usuarios.Include(x => x.Roles).ToList().Select(x =>
                new { x.Id, x.Username, x.PasswordHash, roles = x.Roles.Select(y => new { y.Id, y.Name }) });
            return Results.Ok(users);
        }).WithTags("Account")
        .RequireAuthorization(new AuthorizeAttribute { Roles = "ADMIN" });

        app.MapGet("/Role", (AppDbContext context) =>
        {
            var roles = context.Roles.Include(x => x.Usuarios).ToList().Select(x =>
                new { x.Id, x.Name, users = x.Usuarios.Select(y => new { y.Id, y.Username }) });
            return Results.Ok(roles);
        }).WithTags("Account")
        .RequireAuthorization(new AuthorizeAttribute { Roles = "ADMIN" });
    }

    //METODO PARA CREAR HASH
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    private string CreateToken(Usuario user)
    {
        var claims = new List<Claim>
        {
            new Claim("name", user.Username),
        };

        string roles = string.Join(",", user.Roles.Select(x => x.Name));

        claims.Add(new Claim("role", roles));

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}