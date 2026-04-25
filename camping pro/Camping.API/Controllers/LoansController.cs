using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Camping.Data;
using Camping.Models;

namespace Camping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly CampingContext _context;

        public LoansController(CampingContext context)
        {
            _context = context;
        }

        // GET: api/Loans (Ver historial de préstamos)
        [HttpGet]
        public async Task<IActionResult> GetLoans()
        {
            var loans = await _context.Loans.ToListAsync();
            return Ok(loans);
        }

        
        [HttpPost]
        public async Task<IActionResult> PostLoan([FromBody] Loan loan)
        {
            
            var equipo = await _context.Equipments.FindAsync(loan.EquipmentId);
            if (equipo == null) return NotFound("El equipo no existe");

            
            if (equipo.EquipmentStatus != "Disponible")
                return BadRequest("¡Error! Este equipo ya está prestado.");

           
            equipo.EquipmentStatus = "Prestado";

            
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();

            return Ok(new { message = "¡Préstamo registrado con éxito!" });
        }


     
        [HttpPut("Devolver/{id}")]
        public async Task<IActionResult> DevolverEquipo(int id, [FromQuery] bool conDanos = false)
        {
            var prestamo = await _context.Loans.FindAsync(id);
            if (prestamo == null) return NotFound("Préstamo no encontrado");
            if (prestamo.Status == "Devuelto") return BadRequest("Este equipo ya fue devuelto antes.");

            var equipo = await _context.Equipments.FindAsync(prestamo.EquipmentId);

            prestamo.ReturnDate = DateTime.Now;
            prestamo.Status = "Devuelto";

            if (equipo != null)
            {
                
                if (conDanos)
                {
                    equipo.EquipmentStatus = "Dañado"; 
                }
                else
                {
                    equipo.EquipmentStatus = "Disponible"; 
                }
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Devolución procesada." });
        }
    }
}