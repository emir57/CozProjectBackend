using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfCategoryCompleteReadDal : EfReadRepository<CategoryComplete>, ICategoryCompleteReadDal
{
    public EfCategoryCompleteReadDal(CozProjectDbContext context) : base(context)
    {
    }
}
