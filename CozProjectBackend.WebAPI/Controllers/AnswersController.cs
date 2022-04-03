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
    }
}
