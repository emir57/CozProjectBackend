using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryWriteDal : EfWriteRepository<Category>, ICategoryWriteDal
    {
        public EfCategoryWriteDal(DbContext context) : base(context)
        {
        }
    }
}
