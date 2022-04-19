using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete.QuestionComplete
{
    public class QuestionCompleteWriteManager : IQuestionCompleteWriteService
    {
        private readonly ILanguageMessage _language;
        private readonly IQuestionCompleteWriteDal _questionCompleteWriteDal;

        public QuestionCompleteWriteManager(IQuestionCompleteWriteDal questionCompleteWriteDal, ILanguageMessage language)
        {
            _questionCompleteWriteDal = questionCompleteWriteDal;
            _language = language;
        }

        public async Task<IResult> AddAsync(Entities.Concrete.QuestionComplete questionComplete)
        {
            var result = await _questionCompleteWriteDal.AddAsync(questionComplete);
            if (result)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
        }

        public IResult Delete(Entities.Concrete.QuestionComplete questionComplete)
        {
            _questionCompleteWriteDal.Delete(questionComplete);
            return new SuccessResult(_language.SuccessDelete);
        }
    }
}
