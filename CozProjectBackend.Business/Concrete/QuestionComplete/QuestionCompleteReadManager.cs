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
    public class QuestionCompleteReadManager : IQuestionCompleteReadService
    {
        private readonly ILanguageMessage _language;
        private readonly IQuestionCompleteReadDal _questionCompleteReadDal;

        public QuestionCompleteReadManager(IQuestionCompleteReadDal questionCompleteReadDal, ILanguageMessage language)
        {
            _questionCompleteReadDal = questionCompleteReadDal;
            _language = language;
        }
        public async Task<IDataResult<bool>> CheckQuestionCompleteAsync(int userId, int questionId)
        {
            var categoryComplete = await _questionCompleteReadDal.GetAsync(x => x.UserId == userId && x.QuestionId == questionId);
            if (categoryComplete == null)
            {
                return new SuccessDataResult<bool>(true);
            }
            return new SuccessDataResult<bool>(false);
        }
    }
}
