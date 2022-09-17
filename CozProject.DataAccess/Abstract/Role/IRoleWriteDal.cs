using Core.DataAccess;
using Core.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Abstract
{
    public interface IRoleWriteDal : IWriteRepository<Role>
    {
        Task<UserRole> GetUserRoleById(int userId, int roleId);
        Task AddUserRoleAsync(int userId, int roleId);
        void RemoveUserRole(UserRole userRole);
    }
}
