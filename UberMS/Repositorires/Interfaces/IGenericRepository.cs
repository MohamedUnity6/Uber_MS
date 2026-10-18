namespace UberMS.Repositorires.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);
    }
}
