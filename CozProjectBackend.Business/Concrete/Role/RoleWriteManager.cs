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
    public class RoleWriteManager : IRoleWriteService
    {
        private readonly IRoleWriteDal _roleWriteDal;

        public RoleWriteManager(IRoleWriteDal roleWriteDal)
        {
            _roleWriteDal = roleWriteDal;
        }

        public async Task<IResult> AddAsync(Role entity)
        {
            bool result = await _roleWriteDal.AddAsync(entity);
            if (result)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IResult Delete(Role entity)
        {
            _roleWriteDal.Delete(entity);
            return new SuccessResult();
        }

        public Task<int> SaveAsync()
        {
            return _roleWriteDal.SaveAsync();
        }

        public IResult Update(Role entity)
        {
            bool result = _roleWriteDal.Update(entity);
            if (result)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
