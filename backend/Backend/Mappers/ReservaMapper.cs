using Backend.Domain;
using Backend.Endpoints.DTO;
using Mapster;

namespace Backend.Mappers
{
    public class ReservaMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ReservaDto, ReservaResponseDto>()
                .Map(dest => dest.ReservaId, src => src.ReservaId)
                .Map(dest => dest.ProductoId, src => src.Producto.ProductoId)
                .Map(dest => dest.Usuario, src => src.Usuario)
                .Map(dest => dest.ClienteNombre, src => src.ClienteNombre)
                .Map(dest => dest.EstadoId, src => src.EstadoReserva.EstadoId);

            config.NewConfig<Producto, ProductoResponseDto>()
                .Map(dest => dest.ProductoId, src => src.ProductoId)
                .Map(dest => dest.Barrio, src => src.Barrio)
                .Map(dest => dest.Codigo, src => src.Codigo)
                .Map(dest => dest.Precio, src => src.Precio)
                .Map(dest => dest.UrlImagen, src => src.UrlImagen);

            config.NewConfig<EstadoReserva, EstadosDto>()
             .Map(dest => dest.EstadoId, src => src.EstadoId)
             .Map(dest => dest.Nombre, src => src.Nombre);

        }

    }
}