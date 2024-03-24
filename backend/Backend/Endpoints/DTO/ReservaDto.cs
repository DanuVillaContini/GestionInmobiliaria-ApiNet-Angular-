using Backend.Domain;

namespace Backend.Endpoints.DTO
{
    public class ReservaDto
    {
        public int ReservaId { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public string Usuario { get; set; }
        public string? ClienteNombre { get; set; }
        public int EstadoId { get; set; }
        public required EstadoReserva EstadoReserva { get; set; }
    }
    public class ReservaResponseDto
    {
        public required int ReservaId { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public string? Usuario { get; set; }
        public string? ClienteNombre { get; set; }
        public int EstadoId { get; set; }
        public EstadoReserva EstadoReserva { get; set; }
    }

    public class ReservaRequestDto
    {
        public int ProductoId { get; set; }
        public string Usuario { get; set; }
        public string ClienteNombre { get; set; }
    }
    public class EstadosReservaRequestDto
    {
        public int EstadoId { get; set; }
    }
}
