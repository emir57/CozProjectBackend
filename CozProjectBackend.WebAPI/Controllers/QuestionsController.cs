﻿using Core.Utilities.Result;
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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionWriteService _questionWriteService;
        private readonly IQuestionReadService _questionReadService;
        private readonly IAnswerWriteService _answerWriteService;
        public QuestionsController(IQuestionWriteService questionWriteService, IQuestionReadService questionReadService, IAnswerWriteService answerWriteService)
        {
            _questionWriteService = questionWriteService;
            _questionReadService = questionReadService;
            _answerWriteService = answerWriteService;
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
        public async Task<IActionResult> GetById(int id)
        {
            IDataResult<Question> result = await _questionReadService.GetByIdAsync(id);
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
            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Question question, List<Answer> answers)
        {
            IResult result = _questionWriteService.Update(question);
            await _questionWriteService.SaveAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            IResult result2 = _answerWriteService.UpdateRange(answers);
            await _answerWriteService.SaveAsync();
            if (!result2.Success)
            {
                return BadRequest(result2);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
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
            return Ok(result);
        }
    }
}
