using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [StringLength(30)]
        public string NameUser { get; set; }
        [StringLength(100)]
        public string Correo { get; set; }
        [StringLength(15)]
        public string Contraseña { get; set; }
        public bool EsVendedor { get; set; }
    }
}
