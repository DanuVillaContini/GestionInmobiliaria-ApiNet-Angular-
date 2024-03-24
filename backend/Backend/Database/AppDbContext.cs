using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<EstadoProducto> EstadoProductos { get; set; }
        public DbSet<EstadoReserva> EstadoReservas { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region PRODUCTOS
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    ProductoId = 1,
                    Codigo = "PDVzL-0001",
                    Barrio = "Prospero Mena",
                    Precio = 1000000,
                    Estado = "DISPONIBLE"
                },
                new Producto
                {
                    ProductoId = 2,
                    Codigo = "PDVhL-0002",
                    Barrio = "Modelo",
                    Precio = 2500000,
                    Estado = "DISPONIBLE"

                },
                new Producto
                {
                    ProductoId = 3,
                    Codigo = "PDVkL-0003",
                    Barrio = "Oeste II",
                    Precio = 35000000,
                    Estado = "DISPONIBLE"

                });
            #endregion


            #region ESTADOS PRODUCTOS
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
            #endregion


            #region ESTADOS RESERVAS
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
            #endregion 


            #region ROLES
            modelBuilder.Entity<Rol>().HasData(
               new Rol
               {
                   Id = Guid.NewGuid(),
                   Name = "ADMIN"
               },
               new Rol
               {
                   Id = Guid.NewGuid(),
                   Name = "CLIENTE"
               },
               new Rol
               {
                   Id = Guid.NewGuid(),
                   Name = "VENDEDOR"
               });
            #endregion

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
