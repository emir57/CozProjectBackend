﻿using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete
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
            Category category = await _categoryReadDal.GetByIdAsync(categoryId);
            if (category == null)
            {
                return new ErrorDataResult<Category>(category, _language.FailureGet);
            }
            return new SuccessDataResult<Category>(category, _language.SuccessGet);
        }

        public async Task<IDataResult<List<Category>>> GetCategoriesWithComplete(int userId)
        {
            var result = await _categoryReadDal.GetCategoriesWithComplete(userId);
            return new SuccessDataResult<List<Category>>(result, _language.SuccessList);
        }

        public async Task<IDataResult<List<Category>>> GetListAsync()
        {
            return new SuccessDataResult<List<Category>>(await _categoryReadDal.GetAll().ToListAsync(), _language.SuccessList);
        }
    }
}