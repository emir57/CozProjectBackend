using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IWriteRepository<T> : IRepository<T>
        where T:class,IEntity,new()
    {
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
