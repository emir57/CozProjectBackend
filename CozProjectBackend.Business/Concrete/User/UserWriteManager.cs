using Core.Entities.Concrete;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.BusinessAspects;
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
        private readonly ILanguageMessage _languageMessage;

        public UserWriteManager(IUserWriteDal userWriteDal, ILanguageMessage language)
        {
            _userWriteDal = userWriteDal;
            _languageMessage = language;
        }
        [SecuredOperation("Admin")]
        public async Task<IResult> AddAsync(User entity)
        {
            bool result = await _userWriteDal.AddAsync(entity);
            if (result)
                return new SuccessResult(_languageMessage.SuccessAdd);
            return new ErrorResult(_languageMessage.FailureAdd);
        }
        [SecuredOperation("Admin")]
        public IResult Delete(User entity)
        {
            _userWriteDal.Delete(entity);
            return new SuccessResult(_languageMessage.SuccessDelete);
        }
        [SecuredOperation("Admin")]
        public async Task<int> SaveAsync()
        {
            return await _userWriteDal.SaveAsync();
        }
        [SecuredOperation("Admin")]
        public IResult Update(User entity)
        {
            bool result = _userWriteDal.Update(entity);
            if (result)
                return new SuccessResult(_languageMessage.SuccessUpdate);
            return new ErrorResult(_languageMessage.FailureUpdate);
        }
    }
}
