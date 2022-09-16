using Core.Utilities.Result;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface IAnswerReadService
    {
        Task<IDataResult<List<Answer>>> GetListByQuestionIdAsync(int questionId);
        Task<IDataResult<List<Answer>>> GetListAsync();
        Task<IDataResult<Answer>> GetByIdAsync(int answerId);
    }
}
