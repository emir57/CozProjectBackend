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
    public class AnswersController : Controller
    {
        private readonly IAnswerReadService _answerReadService;
        private readonly IAnswerWriteService _answerWriteService;

        public AnswersController(IAnswerWriteService answerWriteService, IAnswerReadService answerReadService)
        {
            _answerWriteService = answerWriteService;
            _answerReadService = answerReadService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            IDataResult<List<Answer>> result = await _answerReadService.GetListAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            IDataResult<Answer> result = await _answerReadService.GetByIdAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getallbyquestionid")]
        public async Task<IActionResult> GetAllByQuestionId(int questionId)
        {
            IDataResult<List<Answer>> result = await _answerReadService.GetListByQuestionIdAsync(questionId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("add")]
        public async Task<IActionResult> Add(Answer answer)
        {
            IResult result = await _answerWriteService.AddAsync(answer);
            await _answerWriteService.SaveAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("update")]
        public async Task<IActionResult> Update(Answer answer)
        {
            IResult result = _answerWriteService.Update(answer);
            await _answerWriteService.SaveAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("delete")]
        public IActionResult Delete(Answer answer)
        {
            IResult result = _answerWriteService.Delete(answer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
