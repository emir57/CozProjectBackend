using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Abstract.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete.Auth
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserReadService _userReadService;
        private readonly ILanguage _language;

        public AuthManager(ITokenHelper tokenHelper, IUserReadService userReadService, ILanguage language)
        {
            _tokenHelper = tokenHelper;
            _userReadService = userReadService;
            _language = language;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            AccessToken accessToken = _tokenHelper.CreateToken(user, _userReadService.GetRoles(user));
            return new SuccessDataResult<AccessToken>(accessToken,_language.SuccessCreateToken);
        }

        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            User user = (await _userReadService.GetByEmailAsync(userForLoginDto.Email)).Data;
            if(user == null)
            {
                return new ErrorDataResult<User>(_language.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<User>(_language.PasswordIsWrong);
            }
            return new SuccessDataResult<User>(user, _language.LoginSuccess);
        }

        public Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;

        }

        public async Task<IResult> UserExists(string email)
        {
            User user = (await _userReadService.GetByEmailAsync(email)).Data;
            if (user != null)
                return new ErrorResult();
            return new SuccessResult();
        }
    }
}
