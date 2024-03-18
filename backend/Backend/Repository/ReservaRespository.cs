using Backend.Database;
using Backend.Domain;
using Backend.Endpoints.DTO;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public interface IReservaRepository
{
    List<Reserva> GetReservas();
    Reserva GetReservaId(int reservaId);
    void AddNewReserva (ReservaDto reservaDto);
    int UpdateEstadoReserva (int reservaId, ReservaDto reservaDto);

}
public class ReservaRespository(AppDbContext context) : IReservaRepository
{
    public void AddNewReserva(ReservaDto reservaDto)
    {
        Reserva reserva = new Reserva
        {
            Producto = reservaDto.Producto,
            Usuario = reservaDto.Usuario,
            ClienteNombre = reservaDto.ClienteNombre,
            EstadoReserva = reservaDto.EstadoReserva
        };

        context.Reservas.Add(reserva);
        context.SaveChanges();

    }

    public Reserva GetReservaId(int reservaId)
    {
        var reserva = context.Reservas.SingleOrDefault(r => r.ReservaId == reservaId);
        return reserva;
    }

    public List<Reserva> GetReservas()
    {
        var reservas = context.Reservas.ToList();
        return reservas;
    }

    public int UpdateEstadoReserva(int reservaId, ReservaDto reservaDto)
    {
        var reserva = context.Reservas.FirstOrDefault(r => r.ReservaId == reservaId);
        if (reserva != null)
        {
            var reservaUpdate = context.Reservas
                .Where(r => r.ReservaId == reservaId)
                .ExecuteUpdate(update => 
                    update.SetProperty(entity => entity.EstadoReserva, reservaDto.EstadoReserva));

            return reservaUpdate;
        }
        else
        {
            return -1; 
        }
    }

}

