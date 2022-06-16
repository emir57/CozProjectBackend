using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IWriteRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        bool Update(T entity);
        void UpdateRange(List<T> entities);
        bool Delete(T entity);
        void DeleteRange(List<T> entities);
        Task<int> SaveAsync();
    }
}
