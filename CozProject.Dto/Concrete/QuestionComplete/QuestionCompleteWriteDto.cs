using Core.Dtos.Abstract;

namespace CozProject.Dto.Concrete
{
    public sealed class QuestionCompleteWriteDto : IWriteDto
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}
