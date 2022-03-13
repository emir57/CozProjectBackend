using Core.Entities.Concrete;
using Core.Entities.Dtos;
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
        private readonly IRoleReadService _roleReadService;

        public AuthManager(ITokenHelper tokenHelper, IRoleReadService roleReadService)
        {
            _tokenHelper = tokenHelper;
            _roleReadService = roleReadService;
        }

        public Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            _tokenHelper.CreateToken(user,_roleReadService.get)
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
