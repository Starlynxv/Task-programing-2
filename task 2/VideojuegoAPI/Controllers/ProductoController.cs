using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideojuegoAPI.Data;
using VideojuegoAPI.Models;
using VideojuegoAPI.DTOs;

namespace VideojuegoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductoController(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return Ok(await _context.Productos.ToListAsync());
        }

        // Crear un producto nuevo
        [HttpPost]
        public async Task<ActionResult<Producto>> Post(ProductoDto dto)
        {
            var nuevo = new Producto
            {
                Nombre = dto.Nombre,
                Marca = dto.Marca,
                Precio = dto.Precio
            };
            _context.Productos.Add(nuevo);
            await _context.SaveChangesAsync();
            return Ok(nuevo);
        }

        // Actualizar producto
        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> Put(int id, ProductoDto dto)
        {
            var dbObj = await _context.Productos.FindAsync(id);
            if (dbObj == null) return NotFound("No existe ese componente en el inventario.");

            dbObj.Nombre = dto.Nombre;
            dbObj.Marca = dto.Marca;
            dbObj.Precio = dto.Precio;

            await _context.SaveChangesAsync();
            return Ok(dbObj);
        }

        // Borrar producto
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dbObj = await _context.Productos.FindAsync(id);
            if (dbObj == null) return NotFound("No se encontró para eliminar.");

            _context.Productos.Remove(dbObj);
            await _context.SaveChangesAsync();
            return Ok("Producto eliminado del sistema.");
        }
    }
}
