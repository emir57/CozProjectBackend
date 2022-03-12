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
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task SaveAsync();
    }
}
