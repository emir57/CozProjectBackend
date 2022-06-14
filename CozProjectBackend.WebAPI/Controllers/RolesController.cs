using Core.Entities.Concrete;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.DataAccess.Abstract;
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
    public class RolesController : ControllerBase
    {
        private readonly IRoleReadService _roleReadService;
        private readonly IRoleWriteService _roleWriteService;
        private readonly IUserReadService _userReadService;
        public RolesController(IRoleReadService roleReadService, IRoleWriteService roleWriteService, IUserReadService userReadService)
        {
            _roleReadService = roleReadService;
            _roleWriteService = roleWriteService;
            _userReadService = userReadService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(Role role)
        {
            var result = await _roleWriteService.AddAsync(role);
            await _roleWriteService.SaveAsync();
            return Ok(result);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleReadService.GetListAsync();
            return Ok(result);
        }
        [HttpGet("getuserroles")]
        public async Task<IActionResult> GetUserRoles(int userId)
        {
            var getUserResult = await _userReadService.GetByIdAsync(userId);
            if (!getUserResult.Success)
                return BadRequest(getUserResult);
            var result = await _userReadService.GetRolesAsync(getUserResult.Data);
            return Ok(result);
        }
    }
}
