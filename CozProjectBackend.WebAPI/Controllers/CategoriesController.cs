using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers
{
    public class CategoriesController : Controller
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


    }
}
