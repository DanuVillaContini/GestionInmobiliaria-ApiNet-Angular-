using Backend.Domain;
using Backend.Endpoints.DTO;

namespace Backend
{
    public static class ExtensionMethods
    {

        public static ProductoDto ConvertToProductoDto(this Producto p)
        {
            return new(p.Codigo, p.Barrio, p.Precio, p.UrlImagen);
        }
    }
}


