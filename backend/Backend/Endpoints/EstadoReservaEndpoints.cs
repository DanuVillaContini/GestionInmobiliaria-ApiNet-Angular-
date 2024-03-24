using Backend.Service;
using Carter;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Endpoints
{
    public class EstadoReservaEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api/estadoReserva");

            //---GET---
            app.MapGet("/", (IEstadoReservaService estadoReservaService) =>
            {
                var estados = estadoReservaService.GetReservaEstados();

                return Results.Ok(estados);

            }).WithTags("EstadosReserva").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, COMERCIAL, ADMIN" });

            //---GET-ID---
            app.MapGet("/{estadoId:int}", (IEstadoReservaService estadoReservaService, int estadoId) =>
            {
                var estado = estadoReservaService.GetReservaEstado(estadoId);

                return Results.Ok(estado);
            }).WithTags("EstadosReserva").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, COMERCIAL, ADMIN" });
        }
    }
}

