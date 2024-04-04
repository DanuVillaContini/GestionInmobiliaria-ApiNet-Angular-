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
    int UpdateEstadoReserva(int reservaId, EstadosReservaRequestDto reservaDto);
    List<ReservaResponseDto> GetReservasPorEstado(int estadoReservaId);
    void ProcesarSolicitudAprobacion(int reservaId);
    object GetReservasPorUsuario(string username);
}

public class ReservaService(IReservaRepository reservaRepository) : IReservaService
{
    public void AddNewReserva(ReservaRequestDto reservaDto)
    {
        if (reservaDto != null)
        {
            var nuevaReserva = reservaDto.Adapt<ReservaDto>();
            reservaRepository.AddNewReserva(nuevaReserva);
        }
    }

    public ReservaResponseDto GetReservaId(int reservaId)
    {
        return reservaRepository.GetReservaId(reservaId).Adapt<ReservaResponseDto>();
    }

    public List<ReservaResponseDto> GetReservas()
    {
        var reservas = reservaRepository.GetReservas().Adapt<List<ReservaResponseDto>>();

        return reservas;
    }

    public List<ReservaResponseDto> GetReservasPorEstado(int estadoReservaId)
    {
        var reservas = reservaRepository.GetReservasPorEstado(estadoReservaId).Adapt<List<ReservaResponseDto>>();
        return reservas;
    }

    public object GetReservasPorUsuario(string username)
    {
        return reservaRepository.GetReservasPorUsuario(username);
    }

    public void ProcesarSolicitudAprobacion(int reservaId)
    {
        reservaRepository.ProcesarSolicitudAprobacion(reservaId);
    }

    public int UpdateEstadoReserva(int reservaId, EstadosReservaRequestDto reservaDto)
    {
        var reservaDtoConverted = reservaDto.Adapt<ReservaDto>();
        return reservaRepository.UpdateEstadoReserva(reservaId, reservaDtoConverted);
    }

}
