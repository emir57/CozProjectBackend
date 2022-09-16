using Core.DataAccess;
using Core.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Abstract
{
    public interface IRoleReadDal : IReadRepository<Role>
    {
        Task<bool> IsInRole(int userId, int roleId);
    }
}
