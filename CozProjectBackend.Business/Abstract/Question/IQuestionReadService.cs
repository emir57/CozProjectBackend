using Core.Utilities.Result;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface IQuestionReadService
    {
        Task<IDataResult<List<Question>>> GetListByCategoryIdAsync(int categoryId);
        Task<IDataResult<Question>> GetByIdAsync(int questionId);
        Task<IDataResult<List<Question>>> GetListAsync();
        Task<IDataResult<List<Question>>> GetAllWithAnswers(int userId = 0);
        Task<IDataResult<List<Question>>> GetByCategoryIdWithAnswers(int categoryId, int userId = 0);
        IDataResult<Question> GetByIdWithAnswers(int questionId);
    }
}
