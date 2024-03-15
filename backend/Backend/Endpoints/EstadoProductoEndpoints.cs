using Backend.Database;
using Backend.Service;
using Carter;

namespace Backend.Endpoints
{
    public class EstadoProductoEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api/estadoProducto");

            //---GET---
            app.MapGet("/", (IEstadoProductoService estadoProductoService) =>
            {
                var estados = estadoProductoService.GetEstados();

                return Results.Ok(estados);

            }).WithTags("EstadoProducto");

            //---GET-ID---
            app.MapGet("/{estadoId:int}", (IEstadoProductoService estadoProductoService, int estadoId) =>
            {
                var estado = estadoProductoService.GetEstado(estadoId);

                return Results.Ok(estado);
            }).WithTags("EstadoProducto");
        }
    }
}
