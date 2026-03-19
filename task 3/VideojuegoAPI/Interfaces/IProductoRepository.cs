using VideojuegoAPI.Domain.Entities;

namespace VideojuegoAPI.Infrastructure.Interfaces;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetProductos();
    Task AddProducto(Producto producto);
}