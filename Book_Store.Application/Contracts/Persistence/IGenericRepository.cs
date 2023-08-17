﻿namespace Book_Store.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);

        Task<IReadOnlyList<T>> GetAll();

        Task<bool> Exist(int id);

        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);


    }
}
