using AutoMapper;
using Core.DataAccess;
using Core.Dtos.Abstract;
using Core.Entities;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete;

public class ReadBaseService<TEntity, TWriteDto, TReadDto> : IReadBaseService<TEntity, TWriteDto, TReadDto>
    where TEntity : class, IEntity, new()
    where TWriteDto : class, IWriteDto, new()
    where TReadDto : class, IReadDto, new()
{
    private readonly IReadRepository<TEntity> _readRepository;
    private readonly IMapper _mapper;
    private readonly ILanguageMessage _languageMessage;

    public ReadBaseService(IReadRepository<TEntity> readRepository, IMapper mapper, ILanguageMessage languageMessage)
    {
        _readRepository = readRepository;
        _mapper = mapper;
        _languageMessage = languageMessage;
    }

    public async Task<IDataResult<TReadDto>> GetByIdAsync(int id, bool tracking = true)
    {
        TEntity findedEntity = await _readRepository.GetByIdAsync(id, tracking);

        if (findedEntity is null)
            return new ErrorDataResult<TReadDto>(default, _languageMessage.FailureGet);

        TReadDto readDto = _mapper.Map<TReadDto>(findedEntity);
        return new SuccessDataResult<TReadDto>(readDto, _languageMessage.SuccessGet);
    }

    public async Task<IDataResult<List<TReadDto>>> GetListAsync(bool tracking = true)
    {
        IQueryable<TEntity> queryable = _readRepository.GetAll(tracking);

        IQueryable<TReadDto> readDtoQueryable = _mapper.ProjectTo<TReadDto>(queryable);

        List<TReadDto> result = await readDtoQueryable.ToListAsync();

        return new SuccessDataResult<List<TReadDto>>(result, _languageMessage.SuccessList);
    }
}
