using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryCompleteWriteDal : EfWriteRepository<CategoryComplete>, ICategoryCompleteWriteDal
    {
        public EfCategoryCompleteWriteDal(DbContext context) : base(context)
        {
        }
    }
}
