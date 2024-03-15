using Backend.Database;
using Backend.Domain;

namespace Backend.Repository
{
    public interface IEstadoReservaRepository
    {
        List<EstadoReserva> GetReservaEstados();
        EstadoReserva GetReservaEstado(int estadoId);

    }
    public class EstadoReservaRepository(AppDbContext context) : IEstadoReservaRepository
    {
        public EstadoReserva GetReservaEstado(int estadoId)
        {
            var estado = context.EstadoReservas.SingleOrDefault(p => p.EstadoId == estadoId);
            return estado;
        }

        public List<EstadoReserva> GetReservaEstados()
        {
            var estados = context.EstadoReservas.ToList();
            return estados;
        }
    }
}
