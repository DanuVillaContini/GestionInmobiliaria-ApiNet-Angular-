using Backend.Database;
using Backend.Domain;
using Backend.Endpoints.DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public interface IReservaRepository
{
    List<ReservaDto> GetReservas();
    ReservaDto GetReservaId(int reservaId);
    void AddNewReserva (ReservaDto reservaDto);
    int UpdateEstadoReserva (int reservaId, ReservaDto reservaDto);

}
public class ReservaRespository(AppDbContext context) : IReservaRepository
{
    public void AddNewReserva(ReservaDto reservaDto)
    {
        var producto = context.Productos.FirstOrDefault(p => p.ProductoId == reservaDto.ProductoId);
        if (producto == null)
        {
            throw new Exception("No se encontró el producto con el ID proporcionado.");
        }
        var estadoReserva = context.EstadoReservas.FirstOrDefault(e => e.EstadoId == reservaDto.EstadoId);
        if (estadoReserva == null)
        {
            throw new Exception("No se encontró el estado de reserva con el ID proporcionado.");
        }
        var reserva = new Reserva
        {
            ProductoId = reservaDto.ProductoId,
            Producto = producto,
            Usuario = reservaDto.Usuario,
            ClienteNombre = reservaDto.ClienteNombre,
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

    //NO FUNCA-SOLUCIONAR
    public int UpdateEstadoReserva(int reservaId, ReservaDto reservaDto)
    {
        var reserva = context.Reservas.FirstOrDefault(r => r.ReservaId == reservaId);
        if (reserva == null)
            throw new Exception($"ReservaId {reservaId} no existe");

        reserva.Usuario = reservaDto.Usuario;
        reserva.ClienteNombre = reservaDto.ClienteNombre;
        reserva.EstadoId = reservaDto.EstadoReserva.EstadoId; 

        context.SaveChanges();

        return reserva.ReservaId; 
    }



}

