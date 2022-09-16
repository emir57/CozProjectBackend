using Core.Dtos.Abstract;

namespace Core.Dtos.Concrete
{
    public sealed class UserResetPasswordDto : IDto
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
