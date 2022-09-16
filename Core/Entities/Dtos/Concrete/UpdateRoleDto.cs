using Core.Entities.Dtos.Abstract;

namespace Core.Entities.Dtos.Concrete
{
    public sealed class UpdateRoleDto : IDto
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
    }
}
