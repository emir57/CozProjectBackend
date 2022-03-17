using Core.Utilities.Result;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface IAnswerReadService
    {
        Task<IDataResult<List<Answer>>> GetListByQuestionIdAsync(int questionId);
        Task<IDataResult<List<Answer>>> GetListAsync();
        Task<IDataResult<Answer>> GetByIdAsync(int answerId);
    }
}
