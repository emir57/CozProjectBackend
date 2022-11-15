using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.DataAccess.Abstract;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete.QuestionComplete;

public class QuestionCompleteReadManager : IQuestionCompleteReadService
{
    private readonly IQuestionCompleteReadDal _questionCompleteReadDal;

    public QuestionCompleteReadManager(IQuestionCompleteReadDal questionCompleteReadDal)
    {
        _questionCompleteReadDal = questionCompleteReadDal;
    }
    public async Task<IDataResult<bool>> CheckQuestionCompleteAsync(int userId, int questionId)
    {
        Entities.Concrete.QuestionComplete questionComplete = await _questionCompleteReadDal.GetAsync(x => x.UserId == userId && x.QuestionId == questionId);
        if (questionComplete is null)
        {
            return new SuccessDataResult<bool>(true);
        }
        return new SuccessDataResult<bool>(false);
    }
}
