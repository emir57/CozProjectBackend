using AutoMapper;
using Core.DataAccess;
using Core.Dtos.Abstract;
using Core.Entities;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete;

public class ReadBaseService<TEntity, TWriteDto, TReadDto> : IReadBaseService<TEntity, TWriteDto, TReadDto>
    where TEntity : class, IEntity, new()
    where TWriteDto : class, IWriteDto, new()
    where TReadDto : class, IReadDto, new()
{
    private readonly IReadRepository<TEntity> readRepository;
    private readonly IMapper _mapper;

    public ReadBaseService(IReadRepository<TEntity> readRepository, IMapper mapper)
    {
        this.readRepository = readRepository;
        _mapper = mapper;
    }

    public Task<IDataResult<TReadDto>> GetByIdAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IDataResult<List<TReadDto>>> GetListAsync()
    {
        throw new System.NotImplementedException();
    }
}
