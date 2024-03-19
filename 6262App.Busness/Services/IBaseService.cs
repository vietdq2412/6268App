namespace _6262App.Business.Services
{
    public interface IBaseService<T>
    {
        public Task Save(T t);
        public List<T> FindAll();
        public Task<T?> FindById(long? id);
        public Task Delete(long id);
        public Task Update(long id);
    }
}
