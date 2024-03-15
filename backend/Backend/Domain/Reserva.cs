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
        public required Usuario UserVendedor { get; set; }
        public required Usuario Cliente { get; set; }

        [ForeignKey("EstadoId")]
        public required EstadoReserva EstadoReserva { get; set; }

    }
}
