using Core.Entities.Concrete;
using Core.Utilities.Result;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface IRoleWriteService
    {
        Task<IResult> AddAsync(Role entity);
        IResult Update(Role entity);
        IResult Delete(Role entity);
        Task AddUserRoleAsync(int userId, int roleId);
        Task RemoveUserRoleAsync(int userId, int roleId);
        Task<int> SaveAsync();
    }
}
