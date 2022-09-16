using Core.Entities.Concrete;
using Core.Entities.Dtos.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract.Auth
{
    public interface IAuthService
    {
        Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
        Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto);
        Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);
        Task<IResult> UserExistsAsync(string email);
        Task<IResult> ResetPasswordAsync(User user, string oldPassword, string newPassword);
    }
}
