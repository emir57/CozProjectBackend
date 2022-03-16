using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.DataAccess.Abstract
{
    public interface IRoleWriteDal:IWriteRepository<Role>
    {
        Task AddUserRole(int userId,int roleId);
    }
}
