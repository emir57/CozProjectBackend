using Core.Utilities.Result;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface ICategoryReadService
    {
        Task<IDataResult<List<Category>>> GetListAsync();
        Task<IDataResult<Category>> GetByIdAsync(int categoryId);
        Task<IDataResult<List<Category>>> GetCategoriesWithComplete(int userId);
        Task<IDataResult<List<Question>>> GetAllWithAnswers();
    }
}
