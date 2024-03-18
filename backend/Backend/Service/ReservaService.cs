using Backend.Domain;
using Backend.Endpoints.DTO;
using Backend.Repository;
using Mapster;

namespace Backend.Service;
public interface IReservaService
{
    List<ReservaResponseDto> GetReservas();

    ReservaResponseDto GetReservaId(int reservaId);

    void AddNewReserva(ReservaRequestDto reservaDto);
    int UpdateEstadoReserva(int reservaId, ReservaRequestDto reservaDto); 
}

public class ReservaService(IReservaRepository reservaRepository) : IReservaService
{
    public void AddNewReserva(ReservaRequestDto reservaDto)
    {
        var nuevaReserva = reservaDto.Adapt<ReservaDto>();
        reservaRepository.AddNewReserva(nuevaReserva);
    }

    public ReservaResponseDto GetReservaId(int reservaId) => reservaRepository
        .GetReservaId(reservaId)
        .Adapt<ReservaResponseDto>();

    public List<ReservaResponseDto> GetReservas()
    {
        return reservaRepository.GetReservas().Adapt<List<ReservaResponseDto>>();
    }

    public int UpdateEstadoReserva(int reservaId, ReservaRequestDto reservaDto)
    {
        return reservaRepository.UpdateEstadoReserva(reservaId, reservaDto.Adapt<ReservaDto>());
    }
}
