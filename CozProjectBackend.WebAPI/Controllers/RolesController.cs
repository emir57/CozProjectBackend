using Core.Entities.Concrete;
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
        private readonly IRoleWriteDal _roleWriteDal;
        private readonly IRoleReadDal _roleReadDal;
        public RolesController(IRoleReadDal roleReadDal, IRoleWriteDal roleWriteDal)
        {
            _roleReadDal = roleReadDal;
            _roleWriteDal = roleWriteDal;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(Role role)
        {
            bool result = await _roleWriteDal.AddAsync(role);
            await _roleWriteDal.SaveAsync();
            return Ok(result);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            IQueryable<Role> result = _roleReadDal.GetAll();
            return Ok(result);
        }
    }
}
