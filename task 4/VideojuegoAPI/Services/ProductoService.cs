using VideojuegoAPI.Application.Contract;
using VideojuegoAPI.Application;
using VideojuegoAPI.Domain.Entities;
using VideojuegoAPI.DTOs;
using VideojuegoAPI.Infrastructure.Interfaces;

namespace VideojuegoAPI.Application.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProductoDto>> GetProductosAsync()
        {
            var productos = await _repo.GetProductos();
            // Convertimos la lista de la DB a una lista de DTOs para el usuario
            return productos.Select(p => new ProductoDto
            {
                Nombre = p.Nombre,
                Marca = p.Marca,
                Precio = p.Precio
            });
        }

        public async Task AddProductoAsync(ProductoDto dto)
        {
            // AQUÍ VAN LAS VALIDACIONES que pide el profe
            if (string.IsNullOrEmpty(dto.Nombre)) throw new Exception("El nombre es obligatorio");
            if (dto.Precio <= 0) throw new Exception("El precio debe ser mayor a 0");

            var entidad = new Producto
            {
                Nombre = dto.Nombre,
                Marca = dto.Marca,
                Precio = dto.Precio
            };
            await _repo.AddProducto(entidad);
        }
    }
}