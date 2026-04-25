using Camping.Models;
using Camping.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Camping.Data.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly CampingContext _context;

        public EquipmentRepository(CampingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments.ToListAsync();
        }

        public async Task<Equipment> GetByIdAsync(int id)
        {
            return await _context.Equipments.FindAsync(id);
        }

      
        public async Task AddAsync(Equipment equipment)
        {
         
            await _context.Equipments.AddAsync(equipment);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Equipments.FindAsync(id);
            if (item != null)
            {
                _context.Equipments.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}