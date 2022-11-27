using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfCategoryReadDal : EfReadRepository<Category>, ICategoryReadDal
{
    private readonly CozProjectDbContext _context;
    public EfCategoryReadDal(CozProjectDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesWithComplete(int userId)
    {
        var result = from category in _context.Categories
                     select new Category
                     {
                         Id = category.Id,
                         Name = category.Name,
                         TextColor = category.TextColor,
                         BackgroundColor = category.BackgroundColor,
                         CreatedDate = category.CreatedDate,
                         IsComplete = _context.CategoryCompletes.SingleOrDefault(x => x.UserId == userId && x.CategoryId == category.Id) == null ? false : true
                     };
        return await result.ToListAsync();
    }
}
