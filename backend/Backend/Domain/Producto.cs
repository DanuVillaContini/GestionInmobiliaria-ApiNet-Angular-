using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        [StringLength(10)]
        public string Codigo { get; set; }
        [StringLength(30)]
        public string Barrio { get; set; }
        public decimal Precio { get; set; }
        [StringLength(200)]
        public string? UrlImagen { get; set; }

    }
}
