

using VideojuegoAPI.DTOs;

namespace VideojuegoAPI.Application.Contract
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> GetProductosAsync();
        Task AddProductoAsync(ProductoDto dto);
    }
}