using Backend.Endpoints.DTO;
using Backend.Repository;
using Mapster;

namespace Backend.Service
{
    public interface IEstadoProductoService
    {
        List<EstadoProductoResponseDto> GetEstados();
        EstadoProductoResponseDto GetEstado(int estadoId);
    }

    public class EstadoProductoService(IEstadoProductoRepository estadoProductoRepository) : IEstadoProductoService
    {
        public EstadoProductoResponseDto GetEstado(int estadoId) => estadoProductoRepository
            .GetEstado(estadoId)
            .Adapt<EstadoProductoResponseDto>();

        public List<EstadoProductoResponseDto> GetEstados()
        {
            return estadoProductoRepository.GetEstados().Adapt<List<EstadoProductoResponseDto>>();
        }
    }
}
