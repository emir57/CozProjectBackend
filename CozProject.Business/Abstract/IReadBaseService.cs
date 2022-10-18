using Core.Utilities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract;

public interface IReadBaseService<TEntity, TWriteDto, TReadDto>
{
    Task<IDataResult<List<TReadDto>>> GetListAsync();
    Task<IDataResult<TReadDto>> GetByIdAsync(int id);
}
