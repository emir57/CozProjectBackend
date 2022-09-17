using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.DataAccess.Abstract;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete
{
    public class CategoryCompleteReadManager : ICategoryCompleteReadService
    {
        private readonly ICategoryCompleteReadDal _categoryCompleteReadDal;

        public CategoryCompleteReadManager(ICategoryCompleteReadDal categoryCompleteReadDal)
        {
            _categoryCompleteReadDal = categoryCompleteReadDal;
        }

        public async Task<IDataResult<bool>> CheckCategoryCompleteAsync(int userId, int categoryId)
        {
            var categoryComplete = await _categoryCompleteReadDal.GetAsync(x => x.UserId == userId && x.CategoryId == categoryId);
            if (categoryComplete == null)
            {
                return new SuccessDataResult<bool>(true);
            }
            return new SuccessDataResult<bool>(false);
        }
    }
}
