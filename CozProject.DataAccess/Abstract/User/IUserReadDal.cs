using Core.DataAccess;
using Core.Entities.Concrete;
using System.Linq;

namespace CozProject.DataAccess.Abstract
{
    public interface IUserReadDal:IReadRepository<User>
    {
        IQueryable<Role> GetRoles(User user);
    }
}
