using _6282App.core.Models;
using _6282App.Repository;

namespace _6262App.Business.Services
{
    public interface ISupplierService : IBaseService<Supplier>
    {
    }

    public class SupplierService : ISupplierService
    {
        public ISupplierRepository supplierRepository { get; }

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public async Task Save(Supplier supplier)
        {
            await supplierRepository.Add(supplier);
        }

        public List<Supplier> FindAll()
        {
            List<Supplier> list = supplierRepository.FindAll().Result!;
            return list;
        }

        public Task<Supplier?> FindById(long? id)
        {
            return supplierRepository.FindById(id);
        }

        public Task Delete(long id)
        {
            return supplierRepository.Delete(id);
        }


        public Task Update(long id)
        {
            return supplierRepository.Update(supplierRepository.FindById(id).Result!);
        }
    }
}
