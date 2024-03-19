using _6282App.core.Models;
using _6282App.Data;
using Microsoft.EntityFrameworkCore;

namespace _6282App.Repository
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        Task<List<OrderDetail>> findNotOrderedItem();
        Task<List<OrderDetail>> findItemsNotOrderedByProductId(long? id);
    }

    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository 
    {
        private AppDbContext DbContext { get; }

        public OrderDetailRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.DbContext = appDbContext;
        }

        public async Task<List<OrderDetail>> findNotOrderedItem()
        {
            return await DbContext.OrderDetails
                .Where(od => od.OrderId == null)
                .Where(od => od.Order == null)
                .Include(od => od.Product)
                .ToListAsync();
        }

        public async Task<List<OrderDetail>> findItemsNotOrderedByProductId(long? id)
        {
            return await DbContext.OrderDetails
                .Where(od => od.ProductId == id)
                .Where(od => od.Order == null)
                .Include(od => od.Product)
                .ToListAsync();
        }
    }
}