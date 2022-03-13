using Core.Entities.Concrete;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Constants;
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
        private readonly ILanguage _language;
        public RoleWriteManager(IRoleWriteDal roleWriteDal, ILanguage language)
        {
            _roleWriteDal = roleWriteDal;
            _language = language;
        }

        public async Task<IResult> AddAsync(Role entity)
        {
            bool result = true;//await _roleWriteDal.AddAsync(entity);
            if (result)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
        }

        public IResult Delete(Role entity)
        {
            _roleWriteDal.Delete(entity);
            return new SuccessResult(_language.SuccessDelete);
        }

        public Task<int> SaveAsync()
        {
            return _roleWriteDal.SaveAsync();
        }

        public IResult Update(Role entity)
        {
            bool result = _roleWriteDal.Update(entity);
            if (result)
                return new SuccessResult(_language.SuccessUpdate);
            return new ErrorResult(_language.FailureUpdate);
        }
    }
}
