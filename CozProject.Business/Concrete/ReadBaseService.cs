using AutoMapper;
using Core.DataAccess;
using Core.Dtos.Abstract;
using Core.Entities;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete;

public class ReadBaseService<TEntity, TWriteDto, TReadDto> : IReadBaseService<TEntity, TWriteDto, TReadDto>
    where TEntity : class, IEntity, new()
    where TWriteDto : class, IWriteDto, new()
    where TReadDto : class, IReadDto, new()
{
    protected readonly IReadRepository<TEntity> ReadRepository;
    protected readonly IMapper Mapper;
    protected readonly ILanguageMessage LanguageMessage;

    public ReadBaseService(IReadRepository<TEntity> readRepository, IMapper mapper, ILanguageMessage languageMessage)
    {
        ReadRepository = readRepository;
        Mapper = mapper;
        LanguageMessage = languageMessage;
    }

    public virtual async Task<IDataResult<TReadDto>> GetByIdAsync(int id, bool tracking = true)
    {
        TEntity findedEntity = await ReadRepository.GetByIdAsync(id, tracking);

        if (findedEntity is null)
            return new ErrorDataResult<TReadDto>(default, LanguageMessage.FailureGet);

        TReadDto readDto = Mapper.Map<TReadDto>(findedEntity);
        return new SuccessDataResult<TReadDto>(readDto, LanguageMessage.SuccessGet);
    }

    public virtual async Task<IDataResult<List<TReadDto>>> GetListAsync(bool tracking = true)
    {
        IQueryable<TEntity> queryable = ReadRepository.GetAll(tracking);

        IQueryable<TReadDto> readDtoQueryable = Mapper.ProjectTo<TReadDto>(queryable);

        List<TReadDto> result = await readDtoQueryable.ToListAsync();

        return new SuccessDataResult<List<TReadDto>>(result, LanguageMessage.SuccessList);
    }
}
