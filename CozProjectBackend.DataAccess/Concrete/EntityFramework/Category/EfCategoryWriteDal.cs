using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryWriteDal : EfWriteRepository<Category>, ICategoryWriteDal
    {
        public EfCategoryWriteDal(DbContext context) : base(context)
        {
        }
    }
}
