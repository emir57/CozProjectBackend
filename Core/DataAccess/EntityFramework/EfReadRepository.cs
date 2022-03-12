using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfReadRepository<T> : IReadRepository<T>
        where T : class, IEntity, new()
    {
        private readonly DbContext _context;

        public EfReadRepository(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return Table.Where(filter);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return Table.FirstOrDefaultAsync(filter);
        }

        public Task<T> GetByIdAsync(int id)
        {
            return Table.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
