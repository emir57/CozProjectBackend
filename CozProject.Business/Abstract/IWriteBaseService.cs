using Core.Dtos.Abstract;
using Core.Entities;
using Core.Utilities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract;

public interface IWriteBaseService<TEntity, TWriteDto, TReadDto>
    where TEntity : class, IEntity, new()
    where TWriteDto : class, IWriteDto, new()
    where TReadDto : class, IReadDto, new()
{
    Task<IResult> AddAsync(TWriteDto writeDto);
    Task<IResult> UpdateAsync(int id, TWriteDto writeDto);
    IResult Delete(TWriteDto writeDto);
    IResult DeleteRange(List<TWriteDto> writeDtos);
    Task<IResult> AddRangeAsync(List<TWriteDto> writeDtos);
    Task<int> SaveAsync();
}
