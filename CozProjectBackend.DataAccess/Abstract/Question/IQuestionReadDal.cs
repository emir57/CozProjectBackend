using Core.DataAccess;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Abstract
{
    public interface IQuestionReadDal : IReadRepository<Question>
    {
        Task<List<Question>> GetAllWithAnswers(int userId = 0);
        Task<List<Question>> GetByCategoryIdWithAnswers(int categoryId, int userId);
        Question GetByIdWithAnswers(int questionId);
    }
}
