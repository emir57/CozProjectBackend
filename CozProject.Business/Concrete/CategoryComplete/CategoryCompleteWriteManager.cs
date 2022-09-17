using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete
{
    public class CategoryCompleteWriteManager : ICategoryCompleteWriteService
    {
        private readonly ILanguageMessage _language;
        private readonly ICategoryCompleteWriteDal _categoryCompleteWriteDal;

        public CategoryCompleteWriteManager(ICategoryCompleteWriteDal categoryCompleteWriteDal, ILanguageMessage language)
        {
            _categoryCompleteWriteDal = categoryCompleteWriteDal;
            _language = language;
        }

        public async Task<IResult> AddAsync(CategoryComplete categoryComplete)
        {
            var result = await _categoryCompleteWriteDal.AddAsync(categoryComplete);
            if (result)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
        }

        public IResult Delete(CategoryComplete categoryComplete)
        {
            _categoryCompleteWriteDal.Delete(categoryComplete);
            return new SuccessResult(_language.SuccessDelete);
        }
    }
}
