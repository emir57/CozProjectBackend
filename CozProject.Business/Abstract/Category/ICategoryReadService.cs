using Core.Utilities.Result;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract;

public interface ICategoryReadService : IReadBaseService<Category, CategoryWriteDto, CategoryReadDto>
{
    Task<IDataResult<List<Category>>> GetCategoriesWithComplete(int userId);
}
