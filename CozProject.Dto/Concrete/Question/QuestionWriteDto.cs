using Core.Dtos.Abstract;

namespace CozProject.Dto.Concrete
{
    public sealed class QuestionWriteDto : IWriteDto
    {
        public string Content { get; set; }
        public int Score { get; set; }
        public int TeacherId { get; set; }
        public int CategoryId { get; set; }
    }
}
