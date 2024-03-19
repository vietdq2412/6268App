using _6282App.core.Models;
using _6282App.Repository;

namespace _6262App.Business.Services
{
    public interface IOrderService: IBaseService<Order>
    {
        Task<Order> FindByStatus(string status);
    }
    
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository oderRepository;

        public OrderService(IOrderRepository oderRepository)
        {
            this.oderRepository = oderRepository;
        }
        public async Task Save(Order order)
        {
            await oderRepository.Add(order);
        }

        public List<Order> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> FindById(long? id)
        {
            return await oderRepository.FindById(id);
        }
        public Task<Order> FindByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(long id)
        {
            throw new NotImplementedException();
        }

        
    }
}
