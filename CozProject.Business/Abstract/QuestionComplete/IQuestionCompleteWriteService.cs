using Core.Utilities.Result;
using CozProject.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface IQuestionCompleteWriteService
    {
        Task<IResult> AddAsync(QuestionComplete questionComplete);
        IResult Delete(QuestionComplete questionComplete);
        Task<int> SaveAsync();
    }
}
