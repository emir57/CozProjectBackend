using Core.Entities.Concrete;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Constants;
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
        private readonly ILanguage _language;
        public UserReadManager(IUserReadDal userReadDal, ILanguage language)
        {
            _userReadDal = userReadDal;
            _language = language;
        }
        public IDataResult<IQueryable<User>> GetAll()
        {
            return new SuccessDataResult<IQueryable<User>>(_userReadDal.GetAll(),_language.SuccessGet);
        }

        public async Task<IDataResult<User>> GetByEmailAsync(string email)
        {
            User user = await _userReadDal.GetAsync(x => x.Email == email);
            if (user == null)
                return new ErrorDataResult<User>(_language.UserNotFound);
            return new SuccessDataResult<User>(user,_language.SuccessGet);
        }

        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            User user = await _userReadDal.GetByIdAsync(id);
            if (user == null)
                return new ErrorDataResult<User>(_language.UserNotFound);
            return new SuccessDataResult<User>(user,_language.SuccessGet);
        }
    }
}
