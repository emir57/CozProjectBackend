using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.DataAccess.Abstract
{
    public interface IRoleWriteDal : IWriteRepository<Role>
    {
        Task<UserRole> GetUserRoleById(int userId, int roleId);
        Task AddUserRoleAsync(int userId, int roleId);
        void RemoveUserRole(UserRole userRole);
    }
}
