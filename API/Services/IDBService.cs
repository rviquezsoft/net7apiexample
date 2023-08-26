namespace API.Services
{
    public interface IDBService<T> where T : class
    {
        Task<List<T>> Get();
        Task<int> Patch(T entity);
        Task<int> Post(T entity);
    }
}