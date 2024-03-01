using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Domain
{
    [Table("Reserva")]
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }

        [ForeignKey("ProductoId")]
        public required Producto Producto { get; set; }
        [ForeignKey("UsuarioId")]
        public required Usuario Usuario { get; set; }


        [ForeignKey("EstadoId")]
        public required EstadoReserva EstadoReserva { get; set; }

        [ForeignKey("ItemId")]
        public required ItemProducto ItemProducto { get; set; }
    }
}
