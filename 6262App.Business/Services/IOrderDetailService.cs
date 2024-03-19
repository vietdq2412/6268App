using _6282App.core.Models;
using _6282App.Repository;

namespace _6262App.Business.Services
{
    public interface IOrderDetailService : IBaseService<OrderDetail>
    {
        List<OrderDetail> FindItemsNotOrdered();
        List<OrderDetail> FindItemsNotOrderedByProductId(long? id);

    }

    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository oderDetailRepository;

        public OrderDetailService(IOrderDetailRepository oderRepository)
        {
            this.oderDetailRepository = oderRepository;
        }

        public Task Save(OrderDetail orderDetail)
        {
            List<OrderDetail> od = FindItemsNotOrderedByProductId(orderDetail.ProductId);
            if (od.Any())
            {
                OrderDetail existOd = od[0];
                existOd.Quantity += orderDetail.Quantity;
                orderDetail = existOd;
                return oderDetailRepository.Update(orderDetail);
            }
            return oderDetailRepository.Add(orderDetail);
        }

        public List<OrderDetail> FindAll()
        {
            return oderDetailRepository.FindAll().Result!;
        }

        public Task<OrderDetail?> FindById(long? id)
        {
            return oderDetailRepository.FindById(id);
        }

        public List<OrderDetail> FindItemsNotOrdered()
        {
            return oderDetailRepository.findNotOrderedItem().Result;
        }

        public List<OrderDetail> FindItemsNotOrderedByProductId(long? id)
        {
            return oderDetailRepository.findItemsNotOrderedByProductId(id).Result;
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