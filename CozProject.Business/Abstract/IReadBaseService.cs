using Core.Dtos.Abstract;
using Core.Entities;
using Core.Utilities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract;

public interface IReadBaseService<TEntity, TWriteDto, TReadDto>
    where TEntity : class, IEntity, new()
    where TWriteDto : class, IWriteDto, new()
    where TReadDto : class, IReadDto, new()
{
    Task<IDataResult<List<TReadDto>>> GetListAsync(bool tracking = true);
    Task<IDataResult<TReadDto>> GetByIdAsync(int id, bool tracking = true);
}
