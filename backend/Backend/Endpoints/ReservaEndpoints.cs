using Backend.Endpoints.DTO;
using Backend.Service;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Endpoints
{
    public class ReservaEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api/Reserva");

            //---GET---
            app.MapGet("/", (IReservaService reservaService) =>
            {
                var r = reservaService.GetReservas();

                return Results.Ok(r);

            }).WithTags("Reservas");

            //---GET-ID---
            app.MapGet("/{reservaId:int}", (IReservaService reservaService, int reservaId) =>
            {
                var rID = reservaService.GetReservaId(reservaId);

                return Results.Ok(rID);
            }).WithTags("Reservas");

            //---GET-Filtradas-por-estado-de-reservas---
            app.MapGet("/filtroestado/{estadoReservaId:int}", (IReservaService reservaService, int estadoReservaId) =>
            {
                var reservasFiltro = reservaService.GetReservasPorEstado(estadoReservaId);
                return Results.Ok(reservasFiltro);
            }).WithTags("Reservas");

            //---POST---
            app.MapPost("/", ([FromServices] IReservaService reservaService, [FromBody] ReservaRequestDto reservaDto) =>
            {
                reservaService.AddNewReserva(reservaDto);
                return Results.NoContent();
            }).WithTags("Reservas");

            //---PUT-update-estado-reserva---
            app.MapPut("/updateestado/{reservaId:int}", ([FromServices] IReservaService reservaService, int reservaId, [FromBody] EstadosReservaRequestDto reservaDto) =>
            {
                var updated = reservaService.UpdateEstadoReserva(reservaId, reservaDto);
                if (updated > 0)
                    return Results.NoContent();
                else
                    return Results.NotFound();
            }).WithTags("Reservas");
        }
    }
}
