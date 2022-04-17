using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Validators.FluentValidation;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
{
    public class CategoryWriteManager : ICategoryWriteService
    {
        private readonly ICategoryWriteDal _categoryWriteDal;
        private readonly ILanguageMessage _language;
        private readonly ICategoryReadService _categoryReadService;

        public CategoryWriteManager(ILanguageMessage language, ICategoryWriteDal categoryWriteDal, ICategoryReadService categoryReadService)
        {
            _language = language;
            _categoryWriteDal = categoryWriteDal;
            _categoryReadService = categoryReadService;
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IResult> AddAsync(Category entity)
        {
            var result = BusinessRules.Run(
                await CheckCategoryNameAsync(entity));
            if(result != null)
            {
                return result;
            }
            bool addResult = await _categoryWriteDal.AddAsync(entity);
            if (addResult)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
        }

        private async Task<IResult> CheckCategoryNameAsync(Category entity)
        {
            var categories = await _categoryReadService.GetListAsync();
            if (categories.Data.Any(x=>x.Name.ToLower() == entity.Name.ToLower()))
            {
                return new ErrorResult("Böyle bir kategori zaten var");
            }
            return new SuccessResult();
        }

        public IResult Delete(Category entity)
        {
            _categoryWriteDal.Delete(entity);
            return new SuccessResult(_language.SuccessDelete);
        }

        public async Task<int> SaveAsync()
        {
            return await _categoryWriteDal.SaveAsync();
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category entity)
        {
            bool result = _categoryWriteDal.Update(entity);
            if (result)
                return new SuccessResult(_language.SuccessUpdate);
            return new ErrorResult(_language.FailureUpdate);
        }
    }
}
