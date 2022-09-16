using Core.Utilities.Result;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface IQuestionCompleteReadService
    {
        Task<IDataResult<bool>> CheckQuestionCompleteAsync(int userId, int questionId);
    }
}
