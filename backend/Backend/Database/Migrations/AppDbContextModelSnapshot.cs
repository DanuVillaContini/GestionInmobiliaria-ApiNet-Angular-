﻿// <auto-generated />
using System;
using Backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Backend.Domain.EstadoProducto", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EstadoId");

                    b.ToTable("EstadoProducto");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Nombre = "DISPONIBLE"
                        },
                        new
                        {
                            EstadoId = 2,
                            Nombre = "RESERVADO"
                        },
                        new
                        {
                            EstadoId = 3,
                            Nombre = "VENDIDO"
                        });
                });

            modelBuilder.Entity("Backend.Domain.EstadoReserva", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("EstadoId");

                    b.ToTable("EstadoReserva");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Nombre = "INGRESADA"
                        },
                        new
                        {
                            EstadoId = 2,
                            Nombre = "APROBADA"
                        },
                        new
                        {
                            EstadoId = 3,
                            Nombre = "CANCELADA"
                        },
                        new
                        {
                            EstadoId = 4,
                            Nombre = "RECHAZADA"
                        });
                });

            modelBuilder.Entity("Backend.Domain.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Barrio")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImagen")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Barrio = "Prospero Mena",
                            Codigo = "PDVzL-0001",
                            Estado = "DISPONIBLE",
                            Precio = 1000000m
                        },
                        new
                        {
                            ProductoId = 2,
                            Barrio = "Modelo",
                            Codigo = "PDVhL-0002",
                            Estado = "DISPONIBLE",
                            Precio = 2500000m
                        },
                        new
                        {
                            ProductoId = 3,
                            Barrio = "Oeste II",
                            Codigo = "PDVkL-0003",
                            Estado = "DISPONIBLE",
                            Precio = 35000000m
                        });
                });

            modelBuilder.Entity("Backend.Domain.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClienteNombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EstadoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ReservaId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Backend.Domain.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rol");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2d8e88f1-03e3-4944-af6b-df7e70c81dd2"),
                            Name = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("62b19ff8-2cc5-417c-903e-1fe614d6a85d"),
                            Name = "COMERCIAL"
                        },
                        new
                        {
                            Id = new Guid("27167471-a64f-46c3-980a-85db7241e525"),
                            Name = "VENDEDOR"
                        });
                });

            modelBuilder.Entity("Backend.Domain.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("RolUsuario", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UsuariosId")
                        .HasColumnType("TEXT");

                    b.HasKey("RolesId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("RolUsuario");
                });

            modelBuilder.Entity("Backend.Domain.Reserva", b =>
                {
                    b.HasOne("Backend.Domain.EstadoReserva", "EstadoReserva")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoReserva");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("RolUsuario", b =>
                {
                    b.HasOne("Backend.Domain.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
