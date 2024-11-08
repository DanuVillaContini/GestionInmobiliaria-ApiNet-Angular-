﻿using Backend.Endpoints.DTO;
using Backend.Service;
using Carter;
using Microsoft.AspNetCore.Authorization;
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

            }).WithTags("Reservas").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, COMERCIAL, ADMIN" });

            //---GET-ID---
            app.MapGet("/{reservaId:int}", (IReservaService reservaService, int reservaId) =>
            {
                var rID = reservaService.GetReservaId(reservaId);

                return Results.Ok(rID);
            }).WithTags("Reservas").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, COMERCIAL, ADMIN" });

            //---GET-Filtradas-por-estado-de-reservas---
            app.MapGet("/filtroxestado/{estadoReservaId:int}", (IReservaService reservaService, int estadoReservaId) =>
            {
                var reservasFiltro = reservaService.GetReservasPorEstado(estadoReservaId);
                return Results.Ok(reservasFiltro);
            }).WithTags("Reservas").RequireAuthorization(new AuthorizeAttribute { Roles = "COMERCIAL, ADMIN" });

            //---GET-Filtradas-por-UserName---
            app.MapGet("/filtroxusername/{username}", (IReservaService reservaService, string username) =>
            {
                var reservasFiltro = reservaService.GetReservasPorUsuario(username);
                return Results.Ok(reservasFiltro);
            }).WithTags("Reservas").RequireAuthorization(new AuthorizeAttribute { Roles = "COMERCIAL, ADMIN" });

            //---POST---
            app.MapPost("/", ([FromServices] IReservaService reservaService, [FromBody] ReservaRequestDto reservaDto) =>
            {
                reservaService.AddNewReserva(reservaDto);
                return Results.NoContent();
            }).WithTags("Reservas").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, ADMIN" });

            //---PUT-update-estado-reserva---
            app.MapPut("/updateestado/{reservaId:int}", ([FromServices] IReservaService reservaService, int reservaId, [FromBody] EstadosReservaRequestDto reservaDto) =>
            {
                var updated = reservaService.UpdateEstadoReserva(reservaId, reservaDto);
                if (updated > 0)
                    return Results.NoContent();
                else
                    return Results.NotFound();
            }).WithTags("Reservas").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, COMERCIAL, ADMIN" });

            //Peticion-aprobacion-checkout
            app.MapPost("/Aprobar/{reservaId:int}", (IReservaService reservaService, int reservaId) =>
            {
                reservaService.ProcesarSolicitudAprobacion(reservaId);

                return Results.Ok();
            }).WithTags("Reservas").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, COMERCIAL, ADMIN" });
        }
    }
}
