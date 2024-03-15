using Backend.Database;
using Carter;

namespace Backend.Endpoints
{
    public class EstadoProductoEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder routes)
        {
            //var app = routes.MapGroup("/api/estadoProducto");

            //app.MapGet("/", (AppDbContext context) =>
            //{
            //    var estado = context.EstadoProductos.Select(p=> p)

            //    return Results.Ok(estado);

            //}).WithTags("EstadoProducto");

        }
    }
}
