using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
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
