using Backend.Domain;
using Backend.Endpoints.DTO;
using Backend.Repository;
using Mapster;

namespace Backend.Service
{
    public interface IEstadoReservaService
    {
        List<EstadosResponseDto> GetReservaEstados();
        EstadosResponseDto GetReservaEstado(int estadoId);
    }
    public class EstadoReservaService(IEstadoReservaRepository estadoReservaRepository) : IEstadoReservaService
    {
        public EstadosResponseDto GetReservaEstado(int estadoId) => estadoReservaRepository.GetReservaEstado(estadoId)
            .Adapt<EstadosResponseDto>();

        public List<EstadosResponseDto> GetReservaEstados()
        {
            return estadoReservaRepository.GetReservaEstados().Adapt<List<EstadosResponseDto>>();

        }
    }
}
