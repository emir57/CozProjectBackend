using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.DataAccess.Abstract;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete.QuestionComplete
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

        public Task<int> SaveAsync()
        {
            return _questionCompleteWriteDal.SaveAsync();
        }
    }
}
