using Core.Utilities.Result;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface IQuestionCompleteWriteService
    {
        Task<IResult> AddAsync(QuestionComplete questionComplete);
        IResult Delete(QuestionComplete questionComplete);
    }
}
