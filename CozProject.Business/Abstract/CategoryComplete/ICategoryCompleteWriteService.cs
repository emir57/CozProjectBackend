using Core.Utilities.Result;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract;

public interface ICategoryCompleteWriteService : IWriteBaseService<CategoryComplete, CategoryCompleteWriteDto, CategoryCompleteReadDto>
{
    Task<IResult> AddAsync(CategoryComplete categoryComplete);
    IResult Delete(CategoryComplete categoryComplete);
}
