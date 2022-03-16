using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Message;
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
        private readonly ILanguageMessage _languageMessage;
        public RoleWriteManager(IRoleWriteDal roleWriteDal, ILanguageMessage language)
        {
            _roleWriteDal = roleWriteDal;
            _languageMessage = language;
        }
        [CacheRemoveAspect("IRoleReadService.Get")]
        public async Task<IResult> AddAsync(Role entity)
        {
            bool result = true;//await _roleWriteDal.AddAsync(entity);
            if (result)
                return new SuccessResult(_languageMessage.SuccessAdd);
            return new ErrorResult(_languageMessage.FailureAdd);
        }

        public IResult Delete(Role entity)
        {
            _roleWriteDal.Delete(entity);
            return new SuccessResult(_languageMessage.SuccessDelete);
        }

        public Task<int> SaveAsync()
        {
            return _roleWriteDal.SaveAsync();
        }

        public IResult Update(Role entity)
        {
            bool result = _roleWriteDal.Update(entity);
            if (result)
                return new SuccessResult(_languageMessage.SuccessUpdate);
            return new ErrorResult(_languageMessage.FailureUpdate);
        }
    }
}
