using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryCompleteWriteDal : EfWriteRepository<CategoryComplete>, ICategoryCompleteWriteDal
    {
        public EfCategoryCompleteWriteDal(DbContext context) : base(context)
        {
        }
    }
}
