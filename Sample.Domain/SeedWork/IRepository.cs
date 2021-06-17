using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.SeedWork
{
    public interface IRepository<T, TKey> where T : Entity<TKey>
    {
        IEnumerable<T> GetAll(int page, int count);
        Task<IEnumerable<T>> GetAllAsync(int page, int count);
        T Get(TKey id);
        Task<T> GetAsync(TKey id);
        T Add(T entity, string username);
        Task<T> AddAsync(T entity, string username);
        T Update(T entity, string username);
        Task<T> UpdateAsync(T entity, string username);
        bool Delete(TKey id, string username);
        Task<bool> DeleteAsync(TKey id, string username);
    }
}
