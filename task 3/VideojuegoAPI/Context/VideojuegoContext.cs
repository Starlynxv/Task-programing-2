using Microsoft.EntityFrameworkCore;
using VideojuegoAPI.Domain.Entities;

namespace VideojuegoAPI.Infrastructure.Context;

public class VideojuegoContext : DbContext
{
    public VideojuegoContext(DbContextOptions<VideojuegoContext> options) : base(options) { }
    public DbSet<Producto> Productos { get; set; }
}