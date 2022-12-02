using Core.Utilities.Result;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract;

public interface ICategoryCompleteReadService : IReadBaseService<CategoryComplete, CategoryCompleteWriteDto, CategoryCompleteReadDto>
{
    Task<IDataResult<bool>> CheckCategoryCompleteAsync(int userId, int categoryId);
}
