using Microsoft.AspNetCore.Mvc;
using Camping.Models;
using Camping.Data.Repository;

namespace Camping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly EquipmentRepository _repository;


        public EquipmentsController(EquipmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEquipments()
        {
            var equipments = await _repository.GetAllAsync();
            return Ok(equipments);
        }

        [HttpPost]
        public async Task<IActionResult> PostEquipment([FromBody] Equipment equipment)
        {

            await _repository.AddAsync(equipment);

            return CreatedAtAction(nameof(GetEquipments), new { id = equipment.Id }, equipment);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(int id, [FromBody] Equipment equipment)
        {
            if (id != equipment.Id) return BadRequest("El ID no coincide");

            await _repository.UpdateAsync(equipment);
            return Ok(new { message = "Equipo actualizado correctamente" });
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok(new { message = "Equipo eliminado correctamente" });
        }

    }
}