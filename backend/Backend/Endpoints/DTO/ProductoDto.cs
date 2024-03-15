namespace Backend.Endpoints.DTO
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public required string Codigo { get; set; }
        public required string Barrio { get; set; }
        public required decimal Precio { get; set; }
        public string? UrlImagen { get; set; }
    }

    public class ProductoRequestDto
    {
        public required string Codigo { get; set; }
        public required string Barrio { get; set; }
        public required decimal Precio { get; set; }
        public string? UrlImagen { get; set; }
    }

    public class ProductoResponseDto
    {
        public int ProductoId { get; set; }
        public required string Codigo { get; set; }
        public required string Barrio { get; set; }
        public required decimal Precio { get; set; }
        public string? UrlImagen { get; set; }
    }
}
