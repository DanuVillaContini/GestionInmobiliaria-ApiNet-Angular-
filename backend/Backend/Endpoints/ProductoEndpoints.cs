using Backend.Database;
using Backend.Domain;
using Backend.Endpoints.DTO;
using Backend.Service;
using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Endpoints
{
    public class ProductoEndpoints :ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api/Producto");
            //---GET---
            app.MapGet("/", (IProductoService productoService) =>
            {
                var productos = productoService.GetProductos();

                return Results.Ok(productos);

            }).WithTags("Producto");

            //---GET-ID---
            app.MapGet("/{productoId:int}", (IProductoService productoService, int productoId) =>
            {
                var producto = productoService.GetProducto(productoId);

                return Results.Ok(producto);
            }).WithTags("Producto");

            //---POST---
            app.MapPost("/", ([FromServices] IProductoService productoService, [FromBody] ProductoRequestDto productoDto) =>
            {
                productoService.CreateProducto(productoDto);

                return Results.Created();
            }).WithTags("Producto");

            //---PUT---
            app.MapPut("/{productoId}", ([FromServices] IProductoService productoService, int productoId, [FromBody] ProductoRequestDto productoDto) =>
            {
                productoService.UpdateProducto(productoId, productoDto);

                return Results.Ok();
            }).WithTags("Producto");

            //---DELETE---
            app.MapDelete("/{productoId}", (IProductoService productoService, int productoId) =>
            {
                productoService.DeleteProducto(productoId);

                return Results.NoContent();
            }).WithTags("Producto");
        }
    }
}
