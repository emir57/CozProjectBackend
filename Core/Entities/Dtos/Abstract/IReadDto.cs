using System;

namespace Core.Entities.Dtos.Abstract
{
    public interface IReadDto : IDto
    {
        int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
