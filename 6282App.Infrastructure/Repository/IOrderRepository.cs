using _6282App.core.Models;
using _6282App.Data;

namespace _6282App.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> FindByStatus(string status);
    }

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private AppDbContext DbContext { get; }

        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.DbContext = appDbContext;
        }

        public Task<Order> FindByStatus(string status)
        {
            throw new NotImplementedException();
        }
    }
}