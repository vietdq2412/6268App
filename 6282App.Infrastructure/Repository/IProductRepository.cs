using _6282App.core.Models;
using _6282App.Data;
using Microsoft.EntityFrameworkCore;

namespace _6282App.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private AppDbContext DbContext { get; }

        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.DbContext = appDbContext;
        }

        public new async Task<List<Product?>> FindAll()
        {
            return (await DbContext.Products
                .Include(p => p.Supplier)
                .ToListAsync())!;
        }

        public Task<Product?> FindByName(string name)
        {
            throw new NotImplementedException();
        }

       
    }
}