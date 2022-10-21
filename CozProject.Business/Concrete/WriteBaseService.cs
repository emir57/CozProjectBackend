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
    private readonly IWriteRepository<TEntity> _writeRepository;
    private readonly IReadRepository<TEntity> _readRepository;
    private readonly IMapper _mapper;
    private readonly ILanguageMessage _languageMessage;

    public WriteBaseService(IWriteRepository<TEntity> writeRepository, IMapper mapper, ILanguageMessage languageMessage, IReadRepository<TEntity> readRepository)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
        _languageMessage = languageMessage;
        _readRepository = readRepository;
    }

    public async Task<IResult> AddAsync(TWriteDto writeDto)
    {
        TEntity addedEntity = _mapper.Map<TEntity>(writeDto);

        await _writeRepository.AddAsync(addedEntity);

        return new SuccessResult(_languageMessage.SuccessAdd);
    }

    public async Task<IResult> AddRangeAsync(List<TWriteDto> writeDtos)
    {
        List<TEntity> addedEntities = _mapper.Map<List<TEntity>>(writeDtos);

        await _writeRepository.AddRangeAsync(addedEntities);

        return new SuccessResult(_languageMessage.SuccessAdd);
    }

    public IResult Delete(TWriteDto writeDto)
    {
        TEntity deletedEntity = _mapper.Map<TEntity>(writeDto);

        _writeRepository.Delete(deletedEntity);

        return new SuccessResult(_languageMessage.SuccessDelete);
    }

    public IResult DeleteRange(List<TWriteDto> writeDtos)
    {
        List<TEntity> deletedEntities = _mapper.Map<List<TEntity>>(writeDtos);

        _writeRepository.DeleteRange(deletedEntities);

        return new SuccessResult(_languageMessage.SuccessDelete);
    }

    public async Task<int> SaveAsync()
    {
        return await _writeRepository.SaveAsync();
    }

    public async Task<IResult> UpdateAsync(int id, TWriteDto writeDto)
    {
        TEntity updatedEntity = await _readRepository.GetAsync(x => x.Id == id);

        _mapper.Map(writeDto, updatedEntity);

        _writeRepository.Update(updatedEntity);

        return new SuccessResult(_languageMessage.SuccessUpdate);
    }
}
