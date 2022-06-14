using Core.Entities.Concrete;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface IRoleReadService
    {
        Task<IDataResult<Role>> GetByIdAsync(int id, bool tracking = true);
        Task<IDataResult<List<Role>>> GetListAsync(bool tracking = true);
        Task<IResult> IsInRole(int userId, int roleId);
    }
}
