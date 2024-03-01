using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain
{
    [Table("Producto")]
    public class Producto
    {
        //De cada producto se desea informar un código (alfanumérico),
        //un barrio, el precio y un enlace a una imagen ilustrativa.
        [Key]
        public int ProductoId { get; set; }
        public string Codigo { get; set; }
        public string Barrio { get; set; }
        public decimal Precio { get; set; }
        public string? UrlImagen { get; set; }

    }
}
