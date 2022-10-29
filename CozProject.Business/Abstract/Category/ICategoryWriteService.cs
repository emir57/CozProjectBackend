using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;

namespace CozProject.Business.Abstract
{
    public interface ICategoryWriteService : IWriteBaseService<Category,CategoryWriteDto,CategoryReadDto>
    {
    }
}
