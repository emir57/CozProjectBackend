using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Entities.Concrete;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryReadService _categoryReadService;
        private readonly ICategoryWriteService _categoryWriteService;

        public CategoriesController(ICategoryWriteService categoryWriteService, ICategoryReadService categoryReadService)
        {
            _categoryWriteService = categoryWriteService;
            _categoryReadService = categoryReadService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            IDataResult<List<Category>> result = await _categoryReadService.GetListAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            IDataResult<Category> result = await _categoryReadService.GetByIdAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Category category)
        {
            IResult result = await _categoryWriteService.AddAsync(category);
            await _categoryWriteService.SaveAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(Category category)
        {
            IResult result = _categoryWriteService.Update(category);
            await _categoryWriteService.SaveAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            IDataResult<Category> categoryResult = await _categoryReadService.GetByIdAsync(id);
            if (!categoryResult.Success)
            {
                return BadRequest(categoryResult);
            }
            IResult result = _categoryWriteService.Delete(categoryResult.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
