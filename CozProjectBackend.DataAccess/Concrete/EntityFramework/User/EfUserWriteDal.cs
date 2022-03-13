using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProjectBackend.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfUserWriteDal : EfWriteRepository<User>, IUserWriteDal
    {
        public EfUserWriteDal(DbContext context) : base(context)
        {
        }
    }
}
