using Core.Dtos.Abstract;

namespace Core.Dtos.Concrete
{
    public sealed class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
