using Core.Dtos.Abstract;

namespace Core.Dtos.Concrete
{
    public sealed class UpdateRoleDto : IDto
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
    }
}
