using Core.Dtos.Abstract;

namespace CozProject.Dto.Concrete
{
    public sealed class AnswerWriteDto : IWriteDto
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public bool IsTrue { get; set; }
    }
}
