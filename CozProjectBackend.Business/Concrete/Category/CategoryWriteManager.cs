using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
{
    public class CategoryWriteManager : ICategoryWriteService
    {
        private readonly ICategoryWriteDal _categoryWriteDal;
        private readonly ILanguageMessage _language;

        public CategoryWriteManager(ILanguageMessage language, ICategoryWriteDal categoryWriteDal)
        {
            _language = language;
            _categoryWriteDal = categoryWriteDal;
        }

        public async Task<IResult> AddAsync(Category entity)
        {
            bool result = await _categoryWriteDal.AddAsync(entity);
            if (result)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
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

        public IResult Update(Category entity)
        {
            bool result = _categoryWriteDal.Update(entity);
            if (result)
                return new SuccessResult(_language.SuccessUpdate);
            return new ErrorResult(_language.FailureUpdate);
        }
    }
}
