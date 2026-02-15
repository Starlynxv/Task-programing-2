using Microsoft.EntityFrameworkCore;
using VideojuegoAPI.Models;

namespace VideojuegoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}