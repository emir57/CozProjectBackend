using AutoMapper;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.Business.BusinessAspects;
using CozProject.Business.Validators.FluentValidation;
using CozProject.DataAccess.Abstract;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete;

public class CategoryWriteManager : WriteBaseService<Category, CategoryWriteDto, CategoryReadDto>, ICategoryWriteService
{
    public CategoryWriteManager(ICategoryWriteDal writeRepository, IMapper mapper, ILanguageMessage languageMessage, ICategoryReadDal readRepository) : base(writeRepository, mapper, languageMessage, readRepository)
    { 
    }

    [SecuredOperation("Admin")]
    [ValidationAspect(typeof(CategoryValidator))]
    public async override Task<IResult> AddAsync(CategoryWriteDto writeDto)
    {
        IResult result = BusinessRules.Run(
            await CheckCategoryNameAsync(writeDto));
        if (result != null)
        {
            return result;
        }

        return await base.AddAsync(writeDto);
    }

    private async Task<IResult> CheckCategoryNameAsync(CategoryWriteDto writeDto)
    {
        List<Category> categories = await ReadRepository.GetAll().ToListAsync();
        if (categories.Any(x => x.Name.ToLower() == writeDto.Name.ToLower()))
        {
            return new ErrorResult("Böyle bir kategori zaten var");
        }
        return new SuccessResult();
    }
    
    [SecuredOperation("Admin")]
    public override Task<IResult> DeleteAsync(int id)
    {
        return base.DeleteAsync(id);
    }

    [SecuredOperation("Admin")]
    [ValidationAspect(typeof(CategoryValidator))]
    public override Task<IResult> UpdateAsync(int id, CategoryWriteDto writeDto)
    {
        return base.UpdateAsync(id, writeDto);
    }
}
