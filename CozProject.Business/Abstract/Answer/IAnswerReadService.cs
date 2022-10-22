using Core.Utilities.Result;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract;

public interface IAnswerReadService : IReadBaseService<Answer, AnswerWriteDto, AnswerReadDto>
{
    Task<IDataResult<List<Answer>>> GetListByQuestionIdAsync(int questionId);
}
