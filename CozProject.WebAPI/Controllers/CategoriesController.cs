using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers;

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
        IDataResult<List<CategoryReadDto>> result = await _categoryReadService.GetListAsync();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("getallwithcheckcomplete")]
    public async Task<IActionResult> GetAllWithCheckComplete(int userId)
    {
        IDataResult<List<Category>> result = await _categoryReadService.GetCategoriesWithComplete(userId);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        IDataResult<CategoryReadDto> result = await _categoryReadService.GetByIdAsync(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CategoryWriteDto categoryWriteDto)
    {
        IResult result = await _categoryWriteService.AddAsync(categoryWriteDto);
        await _categoryWriteService.SaveAsync();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryWriteDto categoryWriteDto)
    {
        IResult result = await _categoryWriteService.UpdateAsync(id, categoryWriteDto);
        await _categoryWriteService.SaveAsync();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        IResult result = await _categoryWriteService.DeleteAsync(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
