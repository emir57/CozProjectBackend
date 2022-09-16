using Core.Utilities.Result;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface ICategoryReadService
    {
        Task<IDataResult<List<Category>>> GetListAsync();
        Task<IDataResult<Category>> GetByIdAsync(int categoryId);
        Task<IDataResult<List<Category>>> GetCategoriesWithComplete(int userId);
    }
}
