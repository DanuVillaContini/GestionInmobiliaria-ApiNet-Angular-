using Backend.Database;
using Backend.Domain;
using Backend.Endpoints.DTO;
using Carter;

namespace Backend.Endpoints
{
    public class ProductoEndpoints :ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api/Producto");

            app.MapGet("/", (AppDbContext context) =>
            {
                var productos = context.Productos.Select(p => p.ConvertToProductoDto());

                return Results.Ok(productos);

            }).WithTags("Producto");

            app.MapGet("/{idProducto}", (AppDbContext context, int idProducto) =>
            {
                var productos = context.Productos.Where(p => p.ProductoId == idProducto).Select(p => p.ConvertToProductoDto());

                return Results.Ok(productos);
            }).WithTags("Producto");

            app.MapPost("/", (AppDbContext context, ProductoDto productoDto) =>
            {
                Producto producto = new Producto
                {
                    Codigo = productoDto.Codigo,
                    Barrio = productoDto.Barrio,
                    Precio = productoDto.Precio,
                    UrlImagen = productoDto.UrlImagen
                };

                context.Productos.Add(producto);

                context.SaveChanges();

                return Results.Created();
            }).WithTags("Producto");

            app.MapPut("/{idProducto}", (AppDbContext context, int idProducto, ProductoDto productoDto) =>
            {
                var producto = context.Productos.FirstOrDefault(p => p.ProductoId == idProducto);

                if (producto is null)
                    return Results.BadRequest();

                producto.Codigo = productoDto.Codigo;
                producto.Barrio = productoDto.Barrio;
                producto.Precio = productoDto.Precio;
                producto.UrlImagen = productoDto.UrlImagen;

                context.SaveChanges();

                return Results.Ok();
            }).WithTags("Producto");

            app.MapDelete("/{idProducto}", (AppDbContext context, int idProducto) =>
            {
                var producto = context.Productos.FirstOrDefault(p => p.ProductoId == idProducto);

                if (producto is null)
                    return Results.BadRequest();

                context.Productos.Remove(producto);

                context.SaveChanges();

                return Results.NoContent();
            }).WithTags("Producto");
        }
    }
}
