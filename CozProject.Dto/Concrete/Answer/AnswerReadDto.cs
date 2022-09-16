using Core.Dtos.Abstract;
using System;

namespace CozProject.Dto.Concrete
{
    public sealed class AnswerReadDto : IReadDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsTrue { get; set; }
        public QuestionReadDto Question { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
