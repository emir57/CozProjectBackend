using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfCategoryCompleteWriteDal : EfWriteRepository<CategoryComplete>, ICategoryCompleteWriteDal
{
    public EfCategoryCompleteWriteDal(CozProjectDbContext context) : base(context)
    {
    }
}
