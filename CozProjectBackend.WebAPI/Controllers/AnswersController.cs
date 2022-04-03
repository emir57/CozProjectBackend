using CozProjectBackend.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers
{
    public class AnswersController : Controller
    {
        private readonly IAnswerReadDal _answerReadDal;
        private readonly IAnswerWriteDal _answerWriteDal;

        public AnswersController(IAnswerReadDal answerReadDal, IAnswerWriteDal answerWriteDal)
        {
            _answerReadDal = answerReadDal;
            _answerWriteDal = answerWriteDal;
        }

        
    }
}
