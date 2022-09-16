using Core.Dtos.Abstract;
using Core.Dtos.Concrete;
using System;
using System.Collections.Generic;

namespace CozProject.Dto.Concrete
{
    public sealed class QuestionReadDto : IReadDto
    {
        public int Id { get; set; }
        public CategoryReadDto Category { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public bool? Result { get; set; }
        public UserReadDto User { get; set; }
        public ICollection<AnswerReadDto> Answers { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
