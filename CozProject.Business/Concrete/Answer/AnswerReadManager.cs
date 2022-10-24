using AutoMapper;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.DataAccess.Abstract;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete
{
    public class AnswerReadManager : ReadBaseService<Answer, AnswerWriteDto, AnswerReadDto>, IAnswerReadService
    {
        public AnswerReadManager(IAnswerReadDal _answerReadDal, IMapper mapper, ILanguageMessage languageMessage) : base(_answerReadDal, mapper, languageMessage)
        {
        }

        public async Task<IDataResult<List<Answer>>> GetListByQuestionIdAsync(int questionId)
        {
            return new SuccessDataResult<List<Answer>>(await ReadRepository.GetAll(x => x.QuestionId == questionId).ToListAsync(), LanguageMessage.SuccessList);
        }
    }
}
