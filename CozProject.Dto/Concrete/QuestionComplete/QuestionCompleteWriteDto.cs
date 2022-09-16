using Core.Entities.Dtos.Abstract;

namespace CozProject.Dto.Concrete.QuestionComplete
{
    public sealed class QuestionCompleteWriteDto : IWriteDto
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}
