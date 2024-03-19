using _6282App.core.Models;
using _6282App.Data;

namespace _6282App.Repository
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
    }

    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        private AppDbContext DbContext { get; }

        public SupplierRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.DbContext = appDbContext;
        }

        public Task<Supplier> FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}