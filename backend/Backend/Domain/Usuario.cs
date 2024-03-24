using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Username { get; set; } = null!;

        public byte[] PasswordHash { get; set; } = null!;

        public byte[] PasswordSalt { get; set; } = null!;

        public List<Rol> Roles { get; } = [];
    }
}
