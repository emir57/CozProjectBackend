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
        public RolesController(IRoleReadService roleReadService, IRoleWriteService roleWriteService)
        {
            _roleReadService = roleReadService;
            _roleWriteService = roleWriteService;
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
    }
}
