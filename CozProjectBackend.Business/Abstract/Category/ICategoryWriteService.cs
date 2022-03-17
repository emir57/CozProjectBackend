using Core.Utilities.Result;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface ICategoryWriteService
    {
        Task<IResult> AddAsync(Category entity);
        IResult Update(Category entity);
        IResult Delete(Category entity);
        Task<int> SaveAsync();
    }
}
