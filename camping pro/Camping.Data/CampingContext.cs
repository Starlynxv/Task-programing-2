using Microsoft.EntityFrameworkCore;
using Camping.Models; 

namespace Camping.Data
{
    public class CampingContext : DbContext
    {
        public CampingContext(DbContextOptions<CampingContext> options) : base(options)
        {
        }

        
        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}