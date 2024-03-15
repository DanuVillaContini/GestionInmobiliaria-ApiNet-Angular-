using Backend.Endpoints.DTO;
using Backend.Repository;
using Mapster;

namespace Backend.Service
{
    public interface IProductoService
    {
        List<ProductoResponseDto> GetProductos();
        ProductoResponseDto GetProducto(int productoId);
        void CreateProducto(ProductoRequestDto productoDto);
        int UpdateProducto(int productoId, ProductoRequestDto productoDto);
        void DeleteProducto(int productoId);
    }
    public class ProductoService(IProductoRepository productoRepository) : IProductoService
    {
        public void CreateProducto(ProductoRequestDto productoDto)
        {
            productoRepository.AddProducto(productoDto.Adapt<ProductoDto>());
        }

        public void DeleteProducto(int productoId)
        {
            productoRepository.RemoveProducto(productoId);
        }

        public ProductoResponseDto GetProducto(
            int productoId) => productoRepository
            .GetProducto(productoId)
            .Adapt<ProductoResponseDto>();

        public List<ProductoResponseDto> GetProductos()
        {
            return productoRepository.GetProductos().Adapt<List<ProductoResponseDto>>();
        }

        public int UpdateProducto(int productoId, ProductoRequestDto productoDto)
        {
            return productoRepository.UpdateProducto(productoId, productoDto.Adapt<ProductoDto>());
        }
    }
}
