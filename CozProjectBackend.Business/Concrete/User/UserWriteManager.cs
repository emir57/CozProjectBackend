using Core.Entities.Concrete;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
{
    public class UserWriteManager : IUserWriteService
    {
        private readonly IUserWriteDal _userWriteDal;

        public UserWriteManager(IUserWriteDal userWriteDal)
        {
            _userWriteDal = userWriteDal;
        }

        public async Task<IResult> AddAsync(User entity)
        {
            bool result = await _userWriteDal.AddAsync(entity);
            if (result)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IResult Delete(User entity)
        {
            _userWriteDal.Delete(entity);
            return new SuccessResult();
        }

        public async Task<int> SaveAsync()
        {
            return await _userWriteDal.SaveAsync();
        }

        public IResult Update(User entity)
        {
            bool result = _userWriteDal.Update(entity);
            if (result)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
