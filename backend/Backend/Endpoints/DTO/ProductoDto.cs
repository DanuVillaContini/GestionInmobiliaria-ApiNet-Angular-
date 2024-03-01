namespace Backend.Endpoints.DTO
{
    //public class ProductoDto
    //{
    //    public required string Nombre { get; set; }
    //    public string? Descripcion { get; set; }
    //    public required decimal Precio { get; set; }
    //    public string? UrlImagen { get; set; }
    //    public int Stock { get; set; } = 0;
    //}
    public record ProductoDto(string Codigo, string Barrio, decimal Precio, string? UrlImagen);

}
