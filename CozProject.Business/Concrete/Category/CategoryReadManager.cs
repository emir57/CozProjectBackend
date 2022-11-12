using AutoMapper;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.DataAccess.Abstract;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete;

public class CategoryReadManager : ReadBaseService<Category, CategoryWriteDto, CategoryReadDto>, ICategoryReadService
{
    private readonly ICategoryReadDal _categoryReadDal;
    public CategoryReadManager(ICategoryReadDal readRepository, IMapper mapper, ILanguageMessage languageMessage) : base(readRepository, mapper, languageMessage)
    {
        _categoryReadDal = readRepository;
    }

    public async Task<IDataResult<List<Category>>> GetCategoriesWithComplete(int userId)
    {
        List<Category> result = await _categoryReadDal.GetCategoriesWithComplete(userId);
        return new SuccessDataResult<List<Category>>(result, LanguageMessage.SuccessList);
    }
}
