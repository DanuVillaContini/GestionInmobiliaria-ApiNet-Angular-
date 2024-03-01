using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain
{
    public class ItemProducto
    {

        public int ItemId { get; set; }

        [ForeignKey("ProductoId")]
        public required Producto Producto { get; set; }

        [ForeignKey("EstadoId")]
        public required EstadoProducto EstadoProducto { get; set; }

    }
}
