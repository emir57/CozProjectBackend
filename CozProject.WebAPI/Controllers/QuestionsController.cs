using AutoMapper;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionWriteService _questionWriteService;
    private readonly IQuestionReadService _questionReadService;
    private readonly IAnswerWriteService _answerWriteService;
    private readonly IAnswerReadService _answerReadService;
    private readonly IMapper _mapper;
    public QuestionsController(IQuestionWriteService questionWriteService, IQuestionReadService questionReadService, IAnswerWriteService answerWriteService, IAnswerReadService answerReadService, IMapper mapper)
    {
        _questionWriteService = questionWriteService;
        _questionReadService = questionReadService;
        _answerWriteService = answerWriteService;
        _answerReadService = answerReadService;
        _mapper = mapper;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        IDataResult<List<Question>> result = await _questionReadService.GetListAsync();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("getallwithanswers")]
    public async Task<IActionResult> GetAllQuestionsWithAnswers()
    {
        IDataResult<List<Question>> result = await _questionReadService.GetAllWithAnswers();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("getallwithanswersbyuserid")]
    public async Task<IActionResult> GetAllQuestionsWithAnswers(int id)
    {
        IDataResult<List<Question>> result = await _questionReadService.GetAllWithAnswers(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("getbycategoryidwithanswersbyuserid")]
    public async Task<IActionResult> GetByCategoryIdQuestionsWithAnswers(int categoryId, int userId)
    {
        IDataResult<List<Question>> result = await _questionReadService.GetByCategoryIdWithAnswers(categoryId, userId);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("getlistbycategoryid")]
    public async Task<IActionResult> GetListByCategoryId(int categoryId)
    {
        IDataResult<List<Question>> result = await _questionReadService.GetListByCategoryIdAsync(categoryId);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        IDataResult<Question> result = _questionReadService.GetByIdWithAnswers(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(Question question)
    {
        IResult result = await _questionWriteService.AddAsync(question);
        await _questionWriteService.SaveAsync();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        question.Answers.ToList().ForEach(x => x.QuestionId = question.Id);
        IResult result2 = await _answerWriteService.AddRangeAsync(_mapper.Map<List<AnswerWriteDto>>(question.Answers.ToList()));
        await _answerWriteService.SaveAsync();
        if (!result2.Success)
        {
            return BadRequest(result2);
        }
        return Ok(result2);
    }
    [HttpPost("update")]
    public async Task<IActionResult> Update(Question question)
    {
        IResult result = _questionWriteService.Update(question);
        await _questionWriteService.SaveAsync();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        IResult result2 = _answerWriteService.UpdateRange(question.Answers.ToList());
        await _answerWriteService.SaveAsync();
        if (!result2.Success)
        {
            return BadRequest(result2);
        }
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        IDataResult<Question> questionResult = await _questionReadService.GetByIdAsync(id);
        if (!questionResult.Success)
        {
            return BadRequest(questionResult);
        }
        IResult result = _questionWriteService.Delete(questionResult.Data);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        var answers = (await _answerReadService.GetListByQuestionIdAsync(questionResult.Data.Id)).Data;
        await _answerWriteService.DeleteRangeAsync(answers.Select(a => a.Id).ToArray());
        return Ok(result);
    }
}
