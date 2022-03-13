using Core.Entities.Concrete;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface IUserReadService
    {
        Task<IDataResult<User>> GetByIdAsync(int id);
        Task<IDataResult<User>> GetByEmailAsync(string email);
        IDataResult<IQueryable<User>> GetAll();
    }
}
