using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProject.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserWriteDal : EfWriteRepository<User>, IUserWriteDal
    {
        public EfUserWriteDal(DbContext context) : base(context)
        {
        }
    }
}
