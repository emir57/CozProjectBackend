using Core.Entities.Concrete;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface IRoleWriteService
    {
        Task<IResult> AddAsync(Role entity);
        IResult Update(Role entity);
        IResult Delete(Role entity);
        Task AddUserRoleAsync(int userId, int roleId);
        Task<int> SaveAsync();
    }
}
