using Core.Entities.Concrete;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserReadService _userReadService;
        private readonly IUserWriteService _userWriteService;
        public UsersController(IUserReadService userReadService, IUserWriteService userWriteService)
        {
            _userReadService = userReadService;
            _userWriteService = userWriteService;
        }
        [HttpGet("getroles")]
        public async Task<IActionResult> GetRoles(int userId)
        {
            IDataResult<User> userResult = await _userReadService.GetByIdAsync(userId);
            if (!userResult.Success)
            {
                return BadRequest(userResult);
            }
            List<Role> roles = await _userReadService.GetRolesAsync(userResult.Data);
            return Ok(roles);
        }

        [HttpPost("updateprofile")]
        public async Task<IActionResult> UpdateProfile(User user)
        {
            IResult result = _userWriteService.Update(user);
            await _userWriteService.SaveAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
