using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
{
    public class AnswerReadManager : IAnswerReadService
    {
        private readonly IAnswerReadDal _answerReadDal;
        private readonly ILanguageMessage _language;

        public AnswerReadManager(ILanguageMessage language, IAnswerReadDal answerReadDal)
        {
            _language = language;
            _answerReadDal = answerReadDal;
        }

        public async Task<IDataResult<Answer>> GetByIdAsync(int answerId)
        {
            Answer answer = await _answerReadDal.GetByIdAsync(answerId);
            if (answer == null)
            {
                return new ErrorDataResult<Answer>(answer, _language.FailureGet);
            }
            return new SuccessDataResult<Answer>(answer, _language.SuccessGet);
        }

        public async Task<IDataResult<List<Answer>>> GetListAsync()
        {
            return new SuccessDataResult<List<Answer>>(await _answerReadDal.GetAll().ToListAsync(), _language.SuccessList);
        }

        public async Task<IDataResult<List<Answer>>> GetListByQuestionIdAsync(int questionId)
        {
            return new SuccessDataResult<List<Answer>>(await _answerReadDal.GetAll(x => x.QuestionId == questionId).ToListAsync(), _language.SuccessList);
        }
    }
}
