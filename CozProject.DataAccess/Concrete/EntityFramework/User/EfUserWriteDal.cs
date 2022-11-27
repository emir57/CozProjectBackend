using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfUserWriteDal : EfWriteRepository<User>, IUserWriteDal
{
    public EfUserWriteDal(CozProjectDbContext context) : base(context)
    {
    }
}
