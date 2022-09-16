using Core.Entities.Dtos.Abstract;
using System;
using System.Collections.Generic;

namespace CozProject.Dto.Concrete
{
    public sealed class CategoryReadDto : IReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public bool IsComplete { get; set; }
        public ICollection<QuestionReadDto> Questions { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
