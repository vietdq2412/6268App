using _6282App.Data;
using Microsoft.EntityFrameworkCore;

namespace _6282App.Repository
{
    public interface IBaseRepository<T>
    {
        Task<List<T?>> FindAll();
        Task<T?> FindById(long? id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(long? id);
    }

    public class BaseRepository<G>: IBaseRepository<G> where G : class
    {
        private AppDbContext DbContext { get; }
        private DbSet<G> dbSet;

        public BaseRepository(AppDbContext appDbContext)
        {
            this.DbContext = appDbContext;
            this.dbSet = DbContext.Set<G>();
        }
        public async Task<List<G?>> FindAll()
        {
            return (await dbSet.ToListAsync())!;
        }

        public async Task<G?> FindById(long? id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Add(G entity)
        {
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Update(G entity)
        {
            dbSet.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Delete(long? id)
        {
            G g =  FindById(id).Result!;
            dbSet.Remove(g);
            await DbContext.SaveChangesAsync();
        }
    }
}