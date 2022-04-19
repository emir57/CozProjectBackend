using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryReadDal : EfReadRepository<Category>, ICategoryReadDal
    {
        private readonly DbContext _context;
        public EfCategoryReadDal(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesWithComplete(int userId)
        {
            var result = from category in _context.Set<Category>()
                         select new Category
                         {
                             Id = category.Id,
                             Name = category.Name,
                             TextColor = category.TextColor,
                             BackgroundColor = category.BackgroundColor,
                             CreatedDate = category.CreatedDate,
                             isComplete = _context.Set<CategoryComplete>().SingleOrDefault(x => x.UserId == userId && x.CategoryId == category.Id) == null ? false : true
                         };
            return await result.ToListAsync();
        }
    }
}
