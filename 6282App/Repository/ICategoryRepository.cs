using _6282App.core.Models;
using _6282App.Data;

namespace _6282App.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private AppDbContext DbContext { get; }
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.DbContext = appDbContext;
        }
        
        public Task<Category> FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}