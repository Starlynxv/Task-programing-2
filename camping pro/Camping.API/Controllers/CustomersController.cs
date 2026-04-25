using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Camping.Data;
using Camping.Models;

namespace Camping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CampingContext _context;

        public CustomersController(CampingContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return Ok(customer); // Devolvemos el cliente con su nuevo ID
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id) return BadRequest("El ID no coincide");

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Cliente actualizado correctamente" });
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound("Cliente no encontrado");

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Cliente eliminado correctamente" });
        }
    }
}