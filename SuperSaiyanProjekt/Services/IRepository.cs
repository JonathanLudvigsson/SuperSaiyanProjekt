namespace SuperSaiyanProjekt.Services
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Remove(int id);
        Task<T> Update(int id, T entity);
    }
}
