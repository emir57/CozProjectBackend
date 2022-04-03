using CozProjectBackend.Business.Abstract;
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
    }
}
