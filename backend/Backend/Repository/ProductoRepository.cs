using Backend.Database;
using Backend.Domain;
using Backend.Endpoints.DTO;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Backend.Repository
{

    public interface IProductoRepository
    {
        List<Producto> GetProductos();
        Producto GetProducto(int productoId);
        void AddProducto(ProductoDto productoDto);
        int UpdateProducto(int productoId, ProductoDto productoDto);
        void RemoveProducto(int productoId);
    }
    public class ProductoRepository(AppDbContext context) : IProductoRepository
    {
        public void AddProducto(ProductoDto productoDto)
        {
            Producto producto = new Producto
            {
                Codigo = productoDto.Codigo.ToUpper(),
                Precio = productoDto.Precio,
                Barrio = productoDto.Barrio.ToUpper(),
                UrlImagen = productoDto.UrlImagen,
                Estado = "DISPONIBLE"
            };

            context.Productos.Add(producto);

            context.SaveChanges();
        }

        public Producto GetProducto(int productoId)
        {
            var producto = context.Productos.SingleOrDefault(p => p.ProductoId == productoId);
            return producto;

        }

        public List<Producto> GetProductos()
        {
            var productos = context.Productos.ToList();
            return productos;

        }

        public void RemoveProducto(int productoId)
        {
            var producto = context.Productos.FirstOrDefault(p => p.ProductoId == productoId);
            if (producto is null)
                throw new Exception($"El producto con Id {productoId} no existe");
            context.Productos.Remove(producto);
            context.SaveChanges();
        }

        public int UpdateProducto(int productoId, ProductoDto productoDto)
        {
            var rowsAffected = context.Productos
                .Where(x => x.ProductoId == productoId)
                .ExecuteUpdate(update =>
                    update.SetProperty(entity => entity.Codigo, productoDto.Codigo.ToUpper()) // Convertir a mayúsculas
                          .SetProperty(entity => entity.Barrio, productoDto.Barrio.ToUpper()) // Convertir a mayúsculas
                          .SetProperty(entity => entity.Precio, productoDto.Precio)
                          .SetProperty(entity => entity.UrlImagen, productoDto.UrlImagen)); // Convertir a mayúsculas

            return rowsAffected;
        }

    }
}
