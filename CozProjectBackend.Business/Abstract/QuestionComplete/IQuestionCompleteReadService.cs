using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface IQuestionCompleteReadService
    {
        Task<IDataResult<bool>> CheckQuestionCompleteAsync(int userId, int questionId);
    }
}
