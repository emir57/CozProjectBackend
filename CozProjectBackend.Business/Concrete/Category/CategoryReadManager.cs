using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
{
    public class CategoryReadManager : ICategoryReadService
    {
        private readonly ICategoryReadDal _categoryReadDal;
        private readonly ILanguageMessage _language;

        public CategoryReadManager(ICategoryReadDal categoryReadDal, ILanguageMessage language)
        {
            _categoryReadDal = categoryReadDal;
            _language = language;
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int categoryId)
        {
            return new SuccessDataResult<Category>(await _categoryReadDal.GetByIdAsync(categoryId), _language.SuccessGet);
        }

        public async Task<IDataResult<List<Category>>> GetListAsync()
        {
            return new SuccessDataResult<List<Category>>(await _categoryReadDal.GetAll().ToListAsync(), _language.SuccessGet);
        }
    }
}
