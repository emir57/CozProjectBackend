using Core.Entities.Concrete;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.BusinessAspects;
using CozProjectBackend.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        
        public IDataResult<IQueryable<User>> GetAll()
        {
            return new SuccessDataResult<IQueryable<User>>(_userReadDal.GetAll(),_languageMessage.SuccessGet);
        }

        public async Task<IDataResult<User>> GetByEmailAsync(string email)
        {
            User user = await _userReadDal.GetAsync(x => x.Email == email);
            if (user == null)
                return new ErrorDataResult<User>(_languageMessage.UserNotFound);
            return new SuccessDataResult<User>(user,_languageMessage.SuccessGet);
        }

        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            User user = await _userReadDal.GetByIdAsync(id);
            if (user == null)
                return new ErrorDataResult<User>(_languageMessage.UserNotFound);
            return new SuccessDataResult<User>(user,_languageMessage.SuccessGet);
        }

        public IQueryable<Role> GetRoles(User user)
        {
            return _userReadDal.GetRoles(user);
        }
    }
}
