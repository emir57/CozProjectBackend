using Core.Entities.Concrete;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface IUserWriteService
    {
        Task<IResult> AddAsync(User entity);
        IResult Update(User entity);
        IResult Delete(User entity);
        Task<int> SaveAsync();
    }
}
