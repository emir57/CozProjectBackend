using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Message;
using Core.Utilities.Result;
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

        public Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            AccessToken accessToken = _tokenHelper.CreateToken(user, _userReadService.GetRoles(user));
            return new SuccessDataResult<AccessToken>(accessToken, _language.SuccessCreateToken);
        }

        public Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
