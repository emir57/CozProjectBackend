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
public class AnswersController : ControllerBase
{
    private readonly IAnswerReadService _answerReadService;
    private readonly IAnswerWriteService _answerWriteService;

    public AnswersController(IAnswerWriteService answerWriteService, IAnswerReadService answerReadService)
    {
        _answerWriteService = answerWriteService;
        _answerReadService = answerReadService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IDataResult<List<AnswerReadDto>> result = await _answerReadService.GetListAsync();
        if (result.Success is false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        IDataResult<AnswerReadDto> result = await _answerReadService.GetByIdAsync(id);
        if (result.Success is false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("getallbyquestionid")]
    public async Task<IActionResult> GetAllByQuestionId(int questionId)
    {
        IDataResult<List<Answer>> result = await _answerReadService.GetListByQuestionIdAsync(questionId);
        if (result.Success is false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AnswerWriteDto answerWriteDto)
    {
        IResult result = await _answerWriteService.AddAsync(answerWriteDto);
        await _answerWriteService.SaveAsync();
        if (result.Success is false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AnswerWriteDto answerWriteDto)
    {
        IResult result = await _answerWriteService.UpdateAsync(id, answerWriteDto);
        await _answerWriteService.SaveAsync();
        if (result.Success is false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        IDataResult<AnswerReadDto> answerResult = await _answerReadService.GetByIdAsync(id);
        if (answerResult.Success is false)
        {
            return BadRequest(answerResult);
        }
        IResult result = await _answerWriteService.DeleteAsync(answerResult.Data.Id);
        if (result.Success is false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
