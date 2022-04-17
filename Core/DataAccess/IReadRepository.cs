using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IReadRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(int id, bool tracking = true);
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = true);
    }
}
