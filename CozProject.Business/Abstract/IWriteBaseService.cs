using Core.Utilities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract;

public interface IWriteBaseService<TEntity, TWriteDto, TReadDto>
{
    Task<IResult> AddAsync(TWriteDto writeDto);
    IResult Update(TWriteDto writeDto);
    IResult UpdateRange(List<TWriteDto> writeDtos);
    IResult Delete(TWriteDto writeDto);
    IResult DeleteRange(List<TWriteDto> writeDtos);
    Task<IResult> AddRangeAsync(List<TWriteDto> writeDtos);
    Task<int> SaveAsync();
}
