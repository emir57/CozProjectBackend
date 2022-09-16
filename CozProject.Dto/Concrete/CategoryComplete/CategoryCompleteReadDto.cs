using Core.Entities.Dtos.Abstract;
using Core.Entities.Dtos.Concrete;
using System;

namespace CozProject.Dto.Concrete
{
    public sealed class CategoryCompleteReadDto : IReadDto
    {
        public int Id { get; set; }
        public UserReadDto User { get; set; }
        public CategoryReadDto Category { get; set; }


        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
