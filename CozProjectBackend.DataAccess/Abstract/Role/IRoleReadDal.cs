using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.DataAccess.Abstract
{
    public interface IRoleReadDal : IReadRepository<Role>
    {
        Task<bool> IsInRole(int userId, int roleId);
    }
}
