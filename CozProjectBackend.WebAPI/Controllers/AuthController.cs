using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using CozProject.Business.Abstract.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            IDataResult<User> loginResult = await _authService.LoginAsync(userForLoginDto);
            if (loginResult.Success == false)
                return BadRequest(loginResult);

            IDataResult<AccessToken> tokenResult = await _authService.CreateAccessTokenAsync(loginResult.Data);
            if (tokenResult.Success == false)
                return BadRequest(tokenResult);

            var loginResponseDto = new LoginResponseDto()
            {
                Token = tokenResult.Data,
                User = _mapper.Map<LoginedUserDto>(loginResult.Data)
            };
            DataResult<LoginResponseDto> result = new DataResult<LoginResponseDto>(loginResponseDto, true, "Giriş Başarılı");
            return Ok(result);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            IResult userCheckResult = await _authService.UserExistsAsync(userForRegisterDto.Email);
            if (userCheckResult.Success == false)
                return BadRequest(userCheckResult);

            IDataResult<User> registerResult = await _authService.RegisterAsync(userForRegisterDto);
            if (registerResult.Success == false)
                return BadRequest(registerResult);

            return Ok(registerResult);
        }
    }
}
