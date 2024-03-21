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
                    Codigo = "PDVzL-0001",
                    Barrio = "Prospero Mena",
                    Precio = 1000000,
                },
                new Producto
                {
                    ProductoId = 2,
                    Codigo = "PDVhL-0002",
                    Barrio = "Modelo",
                    Precio = 2500000,
                },
                new Producto
                {
                    ProductoId = 3,
                    Codigo = "PDVkL-0003",
                    Barrio = "Oeste II",
                    Precio = 35000000,
                }
                );
                modelBuilder.Entity<EstadoProducto>().HasData(
                new EstadoProducto
                {
                    EstadoId = 1,
                    Nombre = "DISPONIBLE"
                },
                new EstadoProducto
                {
                    EstadoId = 2,
                    Nombre = "RESERVADO"
                },
                new EstadoProducto
                {
                    EstadoId = 3,
                    Nombre = "VENDIDO"
                }); 
                modelBuilder.Entity<EstadoReserva>().HasData(
                new EstadoProducto
                {
                    EstadoId = 1,
                    Nombre = "INGRESADA"
                },
                new EstadoProducto
                {
                    EstadoId = 2,
                    Nombre = "APROBADA"
                },
                new EstadoProducto
                {
                    EstadoId = 3,
                    Nombre = "CANCELADA"
                },
                new EstadoProducto
                {
                    EstadoId = 4,
                    Nombre = "RECHAZADA"
                });
            //modelBuilder.Entity<Usuario>().HasData(
            //    new Usuario
            //    {
            //        UsuarioId = 1,
            //        NameUser = "userTEST1",
            //        Correo = "user_test_1@example",
            //        Contraseña = "userTEST1*",
            //        EsVendedor = true
            //    },
            //    new Usuario
            //    {
            //        UsuarioId = 2,
            //        NameUser = "userTEST2",
            //        Correo = "user_test_2@example",
            //        Contraseña = "userTEST2*",
            //        EsVendedor = false
            //    });

        }
    }
}
