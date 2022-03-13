using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using CozProjectBackend.Business.Abstract.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            IDataResult<User> loginResult = await _authService.LoginAsync(userForLoginDto);
            if (!loginResult.Success)
            {
                return BadRequest(loginResult);
            }
            IDataResult<AccessToken> tokenResult = _authService.CreateAccessToken(loginResult.Data);
            if (!tokenResult.Success)
            {
                return BadRequest(tokenResult);
            }
            return Ok(tokenResult);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            IResult userCheckResult = await _authService.UserExistsAsync(userForRegisterDto.Email);
            if (!userCheckResult.Success)
            {
                return BadRequest(userCheckResult);
            }
            IDataResult<User> registerResult = await _authService.RegisterAsync(userForRegisterDto);
            if (!registerResult.Success)
            {
                return BadRequest(registerResult);
            }
            return Ok(registerResult);
        }
    }
}
