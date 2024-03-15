﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Domain
{
    [Table("EstadoProducto")]
    public class EstadoProducto
    {
        [Key]
        public int EstadoId { get; set; }
        public required string Nombre { get; set; }
    }
}
