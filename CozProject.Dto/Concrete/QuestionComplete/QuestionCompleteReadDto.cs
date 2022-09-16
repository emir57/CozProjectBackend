using Core.Entities.Dtos.Abstract;
using System;

namespace CozProject.Dto.Concrete
{
    public sealed class QuestionCompleteReadDto : IReadDto
    {
        public int Id { get; set; }
        public UserReadDto User { get; set; }
        public CategoryReadDto Category { get; set; }
        public bool? Result { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
