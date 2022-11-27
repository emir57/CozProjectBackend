using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfCategoryWriteDal : EfWriteRepository<Category>, ICategoryWriteDal
{
    public EfCategoryWriteDal(CozProjectDbContext context) : base(context)
    {
    }
}
