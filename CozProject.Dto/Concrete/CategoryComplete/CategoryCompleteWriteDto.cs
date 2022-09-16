using Core.Entities.Dtos.Abstract;

namespace CozProject.Dto.Concrete
{
    public sealed class CategoryCompleteWriteDto : IWriteDto
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
