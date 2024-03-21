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
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        //Vendedor
        public string Usuario { get; set; }

        //Datos CLiente:
        public string ClienteNombre { get; set; }

        //Estado Reserva
        [ForeignKey("EstadoReserva")]
        public int EstadoId { get; set; }
        public EstadoReserva EstadoReserva { get; set; }

    }
}
