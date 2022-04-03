using CozProjectBackend.Business.Abstract;
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
        public QuestionsController(IQuestionWriteService questionWriteService, IQuestionReadService questionReadService)
        {
            _questionWriteService = questionWriteService;
            _questionReadService = questionReadService;
        }
    }
}
