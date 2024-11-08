﻿using Backend.Database;
using Backend.Domain;
using Backend.Endpoints.DTO;
using Backend.Service;
using Carter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

            }).WithTags("Producto").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, ADMIN" });

            //---GET-ID---
            app.MapGet("/{productoId:int}", (IProductoService productoService, int productoId) =>
            {
                var producto = productoService.GetProducto(productoId);

                return Results.Ok(producto);
            }).WithTags("Producto").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, ADMIN" });

            //---POST---
            app.MapPost("/", ([FromServices] IProductoService productoService, [FromBody] ProductoRequestDto productoDto) =>
            {
                productoService.CreateProducto(productoDto);

                return Results.Created();
            }).WithTags("Producto").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, ADMIN" });

            //---PUT---
            app.MapPut("/{productoId}", ([FromServices] IProductoService productoService, int productoId, [FromBody] ProductoRequestDto productoDto) =>
            {
                productoService.UpdateProducto(productoId, productoDto);

                return Results.Ok();
            }).WithTags("Producto").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, ADMIN" });

            //---DELETE---
            app.MapDelete("/{productoId}", (IProductoService productoService, int productoId) =>
            {
                productoService.DeleteProducto(productoId);

                return Results.NoContent();
            }).WithTags("Producto").RequireAuthorization(new AuthorizeAttribute { Roles = "VENDEDOR, ADMIN" });
        }
    }
}
