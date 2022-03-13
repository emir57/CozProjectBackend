using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract.Auth
{
    public interface IAuthService
    {
        Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
        Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        Task<IResult> UserExists(string email); 
    }
}
