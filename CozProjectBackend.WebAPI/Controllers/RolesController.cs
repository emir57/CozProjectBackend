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
        public RolesController(IRoleReadService roleReadService)
        {
            _roleReadService = roleReadService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(Role role)
        {
            //bool result = await _roleWriteService.AddAsync(role);
            //await _roleWriteDal.SaveAsync();
            return Ok();
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = _roleReadService.GetAll();
            return Ok(result);
        }
    }
}
