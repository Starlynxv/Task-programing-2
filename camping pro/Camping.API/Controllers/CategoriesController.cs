using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Camping.Data;
using Camping.Models;

namespace Camping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CampingContext _context;

        public CategoriesController(CampingContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] Category category)
        {
            if (id != category.Id) return BadRequest("El ID no coincide");

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Categoría actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound("Categoría no encontrada");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Categoría eliminada correctamente" });
        }
    }
}