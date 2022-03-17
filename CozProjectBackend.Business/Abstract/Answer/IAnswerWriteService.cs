using Core.Utilities.Result;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface IAnswerWriteService
    {
        Task<IResult> AddAsync(Answer answer);
        IResult Update(Answer answer);
        IResult Delete(Answer answer);
        Task<int> SaveAsync();
    }
}
