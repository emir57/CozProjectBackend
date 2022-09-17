using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete
{
    public class QuestionReadManager : IQuestionReadService
    {
        private readonly IQuestionReadDal _questionReadDal;
        private readonly ILanguageMessage _language;

        public QuestionReadManager(IQuestionReadDal questionReadDal, ILanguageMessage language)
        {
            _questionReadDal = questionReadDal;
            _language = language;
        }

        public async Task<IDataResult<List<Question>>> GetAllWithAnswers(int userId = 0)
        {
            return new SuccessDataResult<List<Question>>(await _questionReadDal.GetAllWithAnswers(userId), _language.SuccessList);
        }

        public async Task<IDataResult<Question>> GetByIdAsync(int questionId)
        {
            Question question = await _questionReadDal.GetByIdAsync(questionId);
            if (question == null)
            {
                return new SuccessDataResult<Question>(question, _language.FailureGet);
            }
            return new SuccessDataResult<Question>(question, _language.SuccessGet);
        }

        public async Task<IDataResult<List<Question>>> GetByCategoryIdWithAnswers(int categoryId, int userId = 0)
        {
            return new SuccessDataResult<List<Question>>(await _questionReadDal.GetByCategoryIdWithAnswers(categoryId, userId), _language.SuccessList);
        }

        public async Task<IDataResult<List<Question>>> GetListAsync()
        {
            return new SuccessDataResult<List<Question>>(await _questionReadDal.GetAll().ToListAsync(), _language.SuccessList);
        }

        public async Task<IDataResult<List<Question>>> GetListByCategoryIdAsync(int categoryId)
        {
            return new SuccessDataResult<List<Question>>(await _questionReadDal.GetAll(x => x.CategoryId == categoryId).ToListAsync(), _language.SuccessList);
        }

        public IDataResult<Question> GetByIdWithAnswers(int questionId)
        {
            return new SuccessDataResult<Question>(_questionReadDal.GetByIdWithAnswers(questionId), _language.SuccessGet);
        }
    }
}
