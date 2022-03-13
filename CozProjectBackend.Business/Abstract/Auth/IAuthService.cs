using Core.Entities.Concrete;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract.Auth
{
    public interface IAuthService
    {
        Task<IDataResult<User>> LoginAsync();
    }
}
