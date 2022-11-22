using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using System.Collections.Generic;

namespace CozProject.Business.Abstract;

public interface IAnswerWriteService : IWriteBaseService<Answer, AnswerWriteDto, AnswerReadDto>
{
    void UpdateRange(List<Answer> answers);
}
