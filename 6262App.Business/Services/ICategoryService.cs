using _6282App.core.Models;
using _6282App.Repository;

namespace _6262App.Business.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
    }

    public class CategoryService : ICategoryService
    {
        public ICategoryRepository categoryRepository { get; }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task Save(Category category)
        {
            return categoryRepository.Add(category);
        }

        public List<Category> FindAll()
        {
            List < Category > list = categoryRepository.FindAll().Result!;
            return list;
        }

        public Task<Category?> FindById(long? id)
        {
            return categoryRepository.FindById(id);
        }

        public Task Delete(long id)
        {
            return categoryRepository.Delete(id);
        }


        public Task Update(long id)
        {
            return categoryRepository.Update(categoryRepository.FindById(id).Result!);
        }
    }
}