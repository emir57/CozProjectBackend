using Core.Utilities.Result;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface ICategoryCompleteReadService
    {
        Task<IDataResult<bool>> CheckCategoryCompleteAsync(int userId, int categoryId);
    }
}
