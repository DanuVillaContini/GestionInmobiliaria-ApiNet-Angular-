using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain
{
    [Table("EstadoReserva")]

    public class EstadoReserva
    {
        [Key]
        public int EstadoId { get; set; }
        public string? Nombre { get; set; }
    }
}
