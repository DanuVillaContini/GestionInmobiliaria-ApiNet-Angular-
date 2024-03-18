using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Domain
{
    [Table("Reserva")]
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }

        //Producto
        [ForeignKey("ProductoId")]
        public required Producto Producto { get; set; }

        //Vendedor
        [ForeignKey("UsuarioId")]
        public required Usuario Usuario { get; set; }

        //Datos CLiente:
        public string ClienteNombre { get; set; }

        //Estado Reserva
        [ForeignKey("EstadoId")]
        public required EstadoReserva EstadoReserva { get; set; }

    }
}
