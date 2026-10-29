using Domain.ApiSecond;
using Microsoft.EntityFrameworkCore;

namespace Repository.ApiSecond.EF
{
    public class CarritoDbContext : DbContext
    {
        public CarritoDbContext(DbContextOptions<CarritoDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Producto => Set<Producto>();
        public DbSet<Cliente> Cliente => Set<Cliente>();
        public DbSet<Carrito> Carrito => Set<Carrito>();
        public DbSet<CarritoItem> CarritoItem => Set<CarritoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
