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
        if (reservaDto != null)
        {
            Reserva reserva = new Reserva
            {
                ProductoId = reservaDto.Producto.ProductoId,
                Usuario = reservaDto.Usuario,
                ClienteNombre = reservaDto.ClienteNombre,
                EstadoId = reservaDto.EstadoReserva.EstadoId
            };

            context.Reservas.Add(reserva);
            context.SaveChanges();
        }
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
    public int UpdateEstadoReserva(int reservaId, ReservaDto reservaDto)
    {
        var reserva = context.Reservas.FirstOrDefault(r => r.ReservaId == reservaId);
        if (reserva == null)
            throw new Exception($"ReservaId {reservaId} no existe");

        reserva.Usuario = reservaDto.Usuario;
        reserva.ClienteNombre = reservaDto.ClienteNombre;
        reserva.EstadoId = reservaDto.EstadoReserva.EstadoId; // Aquí actualiza directamente el EstadoId

        context.SaveChanges();

        return reserva.ReservaId; // Retorna el ID de la reserva actualizada
    }



}

