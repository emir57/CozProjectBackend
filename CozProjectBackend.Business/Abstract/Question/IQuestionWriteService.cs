using Core.Utilities.Result;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface IQuestionWriteService
    {
        Task<IResult> AddAsync(Question question);
        IResult Update(Question question);
        IResult Delete(Question question);
        Task<int> SaveAsync();
    }
}
