using Core.Entities.Concrete;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers;

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
    [HttpPost]
    public async Task<IActionResult> Add(Role role)
    {
        IResult result = await _roleWriteService.AddAsync(role);
        await _roleWriteService.SaveAsync();
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IResult result = await _roleReadService.GetListAsync();
        return Ok(result);
    }
    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetUserRoles([FromRoute] int userId)
    {
        IDataResult<User> getUserResult = await _userReadService.GetByIdAsync(userId);
        if (getUserResult.Success is false)
            return BadRequest(getUserResult);
        List<Role> result = await _userReadService.GetRolesAsync(getUserResult.Data);
        return Ok(result);
    }
}
