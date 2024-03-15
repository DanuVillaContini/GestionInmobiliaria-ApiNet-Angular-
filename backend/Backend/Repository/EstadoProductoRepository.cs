using Backend.Database;
using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public interface IEstadoProductoRepository
    {
        List<EstadoProducto> GetEstados();
        EstadoProducto GetEstado(int estadoId);

    }
    public class EstadoProductoRepository(AppDbContext context) : IEstadoProductoRepository
    {
        public EstadoProducto GetEstado(int estadoId)
        {
            var estado = context.EstadoProductos.SingleOrDefault(p => p.EstadoId == estadoId);
            return estado;
        }

        public List<EstadoProducto> GetEstados()
        {
            var estados = context.EstadoProductos.ToList();
            return estados;
        }
    }
}
