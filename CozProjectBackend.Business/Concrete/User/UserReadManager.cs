using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.BusinessAspects;
using CozProjectBackend.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
{
    public class UserReadManager : IUserReadService
    {
        private readonly IUserReadDal _userReadDal;
        private readonly ILanguageMessage _languageMessage;
        public UserReadManager(IUserReadDal userReadDal, ILanguageMessage language)
        {
            _userReadDal = userReadDal;
            _languageMessage = language;
        }
        [SecuredOperation("Admin")]
        [CacheAspect(5)]
        public async Task<IDataResult<List<User>>> GetListAsync()
        {
            return new SuccessDataResult<List<User>>(await _userReadDal.GetAll().ToListAsync(), _languageMessage.SuccessList);
        }

        public async Task<IDataResult<User>> GetByEmailAsync(string email)
        {
            User user = await _userReadDal.GetAsync(x => x.Email == email);
            if (user == null)
                return new ErrorDataResult<User>(_languageMessage.UserNotFound);
            return new SuccessDataResult<User>(user, _languageMessage.SuccessGet);
        }
        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            User user = await _userReadDal.GetByIdAsync(id);
            if (user == null)
                return new ErrorDataResult<User>(_languageMessage.UserNotFound);
            return new SuccessDataResult<User>(user, _languageMessage.SuccessGet);
        }
        public async Task<List<Role>> GetRolesAsync(User user)
        {
            return await _userReadDal.GetRoles(user).ToListAsync();
        }
    }
}
