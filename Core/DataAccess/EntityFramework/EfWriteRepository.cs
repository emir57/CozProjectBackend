using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfWriteRepository<T> : IWriteRepository<T>
        where T : class, IEntity, new()
    {
        public Task<int> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
