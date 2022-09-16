using Core.Entities.Dtos.Abstract;

namespace Core.Entities.Dtos.Concrete
{
    public sealed class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
