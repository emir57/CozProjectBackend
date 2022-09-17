using Core.Entities.Concrete;
using Core.Utilities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface IUserReadService
    {
        Task<IDataResult<User>> GetByIdAsync(int id);
        Task<IDataResult<User>> GetByEmailAsync(string email);
        Task<IDataResult<List<User>>> GetListAsync();
        Task<List<Role>> GetRolesAsync(User user);
    }
}
