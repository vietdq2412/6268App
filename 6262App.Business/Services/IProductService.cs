using _6282App.core.Models;
using _6282App.Repository;

namespace _6262App.Business.Services
{
    public interface IProductService : IBaseService<Product>
    {
    }

    public class ProductService : IProductService
    {
        public IProductRepository productRepository { get; }

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Save(Product product)
        {
            await productRepository.Add(product);
        }

        public List<Product> FindAll()
        {
            List<Product> list = productRepository.FindAll().Result!;
            return list;
        }

        public async Task<Product?> FindById(long? id)
        {
            return await productRepository.FindById(id);
        }

        public Task Delete(long id)
        {
            return productRepository.Delete(id);
        }


        public Task Update(long id)
        {
            return productRepository.Update(productRepository.FindById(id).Result!);
        }
    }
}
