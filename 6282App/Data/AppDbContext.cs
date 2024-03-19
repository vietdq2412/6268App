using _6282App.core.Models;
using Microsoft.EntityFrameworkCore;

namespace _6282App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var entityObject = (BaseEntity)entity.Entity;
                if (entity.State == EntityState.Added)
                {
                    entityObject.CreatedDate = DateTime.UtcNow;
                }
                entityObject.UpdatedDate = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var entityObject = (BaseEntity)entity.Entity;
                if (entity.State == EntityState.Added)
                {
                    entityObject.CreatedDate = DateTime.UtcNow;
                }
                entityObject.UpdatedDate = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }

    }
}
