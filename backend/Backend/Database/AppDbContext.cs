using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        //Aqui se va a definir las entidades de mi db,osea mis clases dominio:
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<EstadoProducto> EstadoProductos { get; set; }
        public DbSet<EstadoReserva> EstadoReservas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    ProductoId = 1,
                    Codigo = "PDVL-0001",
                    Barrio = "Prospero Mena",
                    Precio = 1000000,
                },
                new Producto
                {
                    ProductoId = 2,
                    Codigo = "PDVL-0002",
                    Barrio = "Modelo",
                    Precio = 2500000,
                },
                new Producto
                {
                    ProductoId = 3,
                    Codigo = "PDVL-0003",
                    Barrio = "Oeste II",
                    Precio = 35000000,
                }
                );
        }
    }
}
