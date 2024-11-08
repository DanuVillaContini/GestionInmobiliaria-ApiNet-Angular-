﻿using Backend.Database;
using Backend.Domain;
using Backend.Endpoints.DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public interface IReservaRepository
{
    List<ReservaDto> GetReservas();
    ReservaDto GetReservaId(int reservaId);
    void AddNewReserva(ReservaDto reservaDto);
    int UpdateEstadoReserva(int reservaId, ReservaDto reservaDto);
    List<ReservaDto> GetReservasPorEstado(int estadoReservaId);
    void ProcesarSolicitudAprobacion(int reservaId);
    object GetReservasPorUsuario(string username);

}
public class ReservaRespository(AppDbContext context) : IReservaRepository
{
    public void AddNewReserva(ReservaDto reservaDto)
    {
        var producto = context.Productos.FirstOrDefault(p => p.ProductoId == reservaDto.ProductoId);
        if (producto == null || producto.Estado != "DISPONIBLE")
        {
            throw new Exception($"IdProducto {producto.ProductoId} no existe o no esta disponible");
        }
        var estadoReserva = context.EstadoReservas.FirstOrDefault(e => e.EstadoId == 1);
        if (estadoReserva == null)
        {
            throw new Exception($"No se encontró el estado de reserva con el ID{estadoReserva.EstadoId}");
        }

        producto.Estado = "RESERVADO";
        var reserva = new Reserva
        {
            ProductoId = reservaDto.ProductoId,
            Producto = producto,
            Usuario = reservaDto.Usuario.ToUpper(),
            ClienteNombre = reservaDto.ClienteNombre.ToUpper(),
            EstadoId = reservaDto.EstadoId,
            EstadoReserva = estadoReserva
        };

        context.Reservas.Add(reserva);
        context.SaveChanges();
    }

    public ReservaDto GetReservaId(int reservaId)
    {
        var reserva = context.Reservas
            .Where(r => r.ReservaId == reservaId)
            .Include(r => r.Producto)
            .Include(r => r.EstadoReserva)
            .FirstOrDefault();

        return reserva.Adapt<ReservaDto>(); ;
    }

    public List<ReservaDto> GetReservas()
    {
        var reservas = context.Reservas
            .Include(r => r.Producto)
            .Include(r => r.EstadoReserva)
            .ToList();

        return reservas.Adapt<List<ReservaDto>>();
    }

    public List<ReservaDto> GetReservasPorEstado(int estadoReservaId)
    {
        var reservas = context.Reservas
            .Where(e => e.EstadoReserva.EstadoId == estadoReservaId)
            .Include(r => r.Producto)
            .Include(r => r.EstadoReserva)
            .ToList();

        return reservas.Adapt<List<ReservaDto>>();
    }

    public object GetReservasPorUsuario(string username)
    {
        if (username.ToUpper() == "TODO")
        {
            var reservasPorUsuario = context.Reservas
                .GroupBy(r => r.Usuario)
                .Select(g => new { Usuario = g.Key, NumeroReservas = g.Count() })
                .ToList();
            return reservasPorUsuario;
        }
        else
        {
            var numeroReservas = context.Reservas
                .Where(r => r.Usuario.ToUpper() == username.ToUpper())
                .Count();
            return numeroReservas;
        }
    }

    public void ProcesarSolicitudAprobacion(int reservaId)
    {
        var reserva = context.Reservas
        .Include(r => r.Producto)
        .Include(r => r.EstadoReserva)
        .FirstOrDefault(r => r.ReservaId == reservaId);

        if (reserva == null)
            throw new Exception($"La reserva con el ID {reservaId} no existe.");

        var producto = reserva.Producto;

        if (producto.Barrio == "X" && producto.Precio <= 100000)
        {
            reserva.EstadoId = 2;
            producto.Estado = "VENDIDO";
        }
        else
            throw new Exception($"ReservaId {producto.ProductoId} no obtuvo aprobacion directa, requiere examinacion detenida");


        context.SaveChanges();
    }

    public int UpdateEstadoReserva(int reservaId, ReservaDto reservaDto)
    {
        var reserva = context.Reservas.FirstOrDefault(r => r.ReservaId == reservaId);
        if (reserva == null)
            throw new Exception($"ReservaId {reservaId} no existe");

        var producto = context.Productos.FirstOrDefault(p => p.ProductoId == reserva.ProductoId);
        if (producto == null)
            throw new Exception($"ProductoId {reserva.ProductoId} no existe");

        switch (reservaDto.EstadoId)
        {
            case 2:
                reserva.EstadoId = reservaDto.EstadoId;
                producto.Estado = "VENDIDO";
                break;
            case 3:
                reserva.EstadoId = reservaDto.EstadoId;
                producto.Estado = "DISPONIBLE";
                break;
            case 4:
                reserva.EstadoId = reservaDto.EstadoId;
                producto.Estado = "DISPONIBLE";
                break;
            default:
                throw new Exception("Estado de reserva no válido.");
        }

        context.SaveChanges();

        return reserva.ReservaId;
    }

}


