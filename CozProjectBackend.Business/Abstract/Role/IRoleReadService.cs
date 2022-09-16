using Core.Entities.Concrete;
using Core.Utilities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface IRoleReadService
    {
        Task<IDataResult<Role>> GetByIdAsync(int id, bool tracking = true);
        Task<IDataResult<List<Role>>> GetListAsync(bool tracking = true);
        Task<IResult> IsInRole(int userId, int roleId);
    }
}
