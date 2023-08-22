namespace Book_Store.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);

        Task<IReadOnlyList<T>> GetAll();

        Task<List<T>> GetList();

        Task<bool> Exist(int id);

        Task<T> Add(T entity);

        Task Update(T entity);

        Task UpdateRange(List<T> entities);

        Task Delete(T entity);


    }
}
