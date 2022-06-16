﻿using Core.Entities.Concrete;
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
        Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);
        Task<IResult> UserExistsAsync(string email);
        Task<IResult> ResetPasswordAsync(User user, string newPassword);
    }
}
