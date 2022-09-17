using Core.Utilities.Result;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface IAnswerWriteService
    {
        Task<IResult> AddAsync(Answer answer);
        IResult Update(Answer answer);
        IResult UpdateRange(List<Answer> answers);
        IResult Delete(Answer answer);
        IResult DeleteRange(List<Answer> answers);
        Task<int> SaveAsync();
        Task<IResult> AddRangeAsync(List<Answer> answers);
    }
}
