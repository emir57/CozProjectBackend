using AutoMapper;
using Core.DataAccess;
using Core.Dtos.Abstract;
using Core.Entities;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete;

public class WriteBaseService<TEntity, TWriteDto, TReadDto> : IWriteBaseService<TEntity, TWriteDto, TReadDto>
    where TEntity : class, IEntity, new()
    where TWriteDto : class, IWriteDto, new()
    where TReadDto : class, IReadDto, new()
{
    protected readonly IWriteRepository<TEntity> WriteRepository;
    protected readonly IReadRepository<TEntity> ReadRepository;
    protected readonly IMapper Mapper;
    protected readonly ILanguageMessage LanguageMessage;

    public WriteBaseService(IWriteRepository<TEntity> writeRepository, IMapper mapper, ILanguageMessage languageMessage, IReadRepository<TEntity> readRepository)
    {
        WriteRepository = writeRepository;
        Mapper = mapper;
        LanguageMessage = languageMessage;
        ReadRepository = readRepository;
    }

    public virtual async Task<IResult> AddAsync(TWriteDto writeDto)
    {
        TEntity addedEntity = Mapper.Map<TEntity>(writeDto);

        await WriteRepository.AddAsync(addedEntity);

        return new SuccessResult(LanguageMessage.SuccessAdd);
    }

    public virtual async Task<IResult> AddRangeAsync(List<TWriteDto> writeDtos)
    {
        List<TEntity> addedEntities = Mapper.Map<List<TEntity>>(writeDtos);

        await WriteRepository.AddRangeAsync(addedEntities);

        return new SuccessResult(LanguageMessage.SuccessAdd);
    }

    public async Task<IResult> DeleteAsync(int id)
    {
        TEntity entity = await ReadRepository.GetAsync(e => e.Id == id);
        
        WriteRepository.Delete(entity);

        return new SuccessResult(LanguageMessage.SuccessDelete);
    }

    public virtual IResult DeleteRange(int[] ids)
    {
        WriteRepository.DeleteRange(ids);

        return new SuccessResult(LanguageMessage.SuccessDelete);
    }

    public virtual async Task<int> SaveAsync()
    {
        return await WriteRepository.SaveAsync();
    }

    public virtual async Task<IResult> UpdateAsync(int id, TWriteDto writeDto)
    {
        TEntity updatedEntity = await ReadRepository.GetAsync(x => x.Id == id);

        Mapper.Map(writeDto, updatedEntity);

        await WriteRepository.UpdateAsync(updatedEntity);

        return new SuccessResult(LanguageMessage.SuccessUpdate);
    }
}
