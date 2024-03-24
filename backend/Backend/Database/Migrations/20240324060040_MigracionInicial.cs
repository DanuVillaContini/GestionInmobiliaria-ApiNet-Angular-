using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoProducto",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoProducto", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoReserva",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoReserva", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Barrio = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    UrlImagen = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Usuario = table.Column<string>(type: "TEXT", nullable: false),
                    ClienteNombre = table.Column<string>(type: "TEXT", nullable: false),
                    EstadoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reserva_EstadoReserva_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoReserva",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsuariosId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => new { x.RolesId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_RolUsuario_Rol_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuario_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoProducto",
                columns: new[] { "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "DISPONIBLE" },
                    { 2, "RESERVADO" },
                    { 3, "VENDIDO" }
                });

            migrationBuilder.InsertData(
                table: "EstadoReserva",
                columns: new[] { "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "INGRESADA" },
                    { 2, "APROBADA" },
                    { 3, "CANCELADA" },
                    { 4, "RECHAZADA" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Barrio", "Codigo", "Estado", "Precio", "UrlImagen" },
                values: new object[,]
                {
                    { 1, "Prospero Mena", "PDVzL-0001", "DISPONIBLE", 1000000m, null },
                    { 2, "Modelo", "PDVhL-0002", "DISPONIBLE", 2500000m, null },
                    { 3, "Oeste II", "PDVkL-0003", "DISPONIBLE", 35000000m, null }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("42d49566-7183-4848-beaf-c4b483eb27fd"), "COMERCIAL" },
                    { new Guid("9ae8426a-7c40-44d1-aea1-ed6dd0537f2a"), "ADMIN" },
                    { new Guid("fa99ddf7-3ba4-494a-bc62-051fc9d0826d"), "VENDEDOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_EstadoId",
                table: "Reserva",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ProductoId",
                table: "Reserva",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuariosId",
                table: "RolUsuario",
                column: "UsuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadoProducto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "EstadoReserva");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
