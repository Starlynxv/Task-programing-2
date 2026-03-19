using Microsoft.EntityFrameworkCore;
using VideojuegoAPI.Domain.Entities;
using VideojuegoAPI.Infrastructure.Context; 
using VideojuegoAPI.Infrastructure.Interfaces;

namespace VideojuegoAPI.Infrastructure.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly VideojuegoContext _context; 

    
    public ProductoRepository(VideojuegoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetProductos()
    {
        return await _context.Productos.ToListAsync();
    }

    public async Task AddProducto(Producto producto)
    {
        await _context.Productos.AddAsync(producto);
        await _context.SaveChangesAsync();
    }
}