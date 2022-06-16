using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Abstract.Auth;
using CozProjectBackend.Business.Validators.FluentValidation;
using FluentEntity_ConsoleApp.FEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete.Auth
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserReadService _userReadService;
        private readonly IUserWriteService _userWriteService;
        private readonly ILanguageMessage _language;
        private readonly IRoleWriteService _roleWriteService;

        public AuthManager(ITokenHelper tokenHelper, IUserReadService userReadService, ILanguageMessage language, IUserWriteService userWriteService, IRoleWriteService roleWriteService)
        {
            _tokenHelper = tokenHelper;
            _userReadService = userReadService;
            _language = language;
            _userWriteService = userWriteService;
            _roleWriteService = roleWriteService;
        }

        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            AccessToken accessToken = _tokenHelper.CreateToken(user, await _userReadService.GetRolesAsync(user));
            return new SuccessDataResult<AccessToken>(accessToken, _language.SuccessCreateToken);
        }
        [ValidationAspect(typeof(UserForLoginValidator))]
        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            User user = (await _userReadService.GetByEmailAsync(userForLoginDto.Email)).Data;
            if (user == null)
            {
                return new ErrorDataResult<User>(_language.UserNotFound);
            }
            if (!user.EmailConfirmed)
            {
                //TODO: send email verification
                return new ErrorDataResult<User>(_language.FailEmailConfirm);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<User>(_language.PasswordIsWrong);
            }
            return new SuccessDataResult<User>(user, _language.LoginSuccess);
        }
        [ValidationAspect(typeof(UserForRegisterValidator))]
        public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            User user = new FluentEntity<User>()
                .AddParameter(x => x.FirstName, userForRegisterDto.FirstName)
                .AddParameter(x => x.LastName, userForRegisterDto.LastName)
                .AddParameter(x => x.Email, userForRegisterDto.Email)
                .AddParameter(x => x.PasswordHash, passwordHash)
                .AddParameter(x => x.PasswordSalt, passwordSalt)
                .AddParameter(x => x.EmailConfirmed, false)
                .AddParameter(x => x.Score, 0)
                .GetEntity();
            IResult result = await _userWriteService.AddAsync(user);
            await _userWriteService.SaveAsync();
            await _roleWriteService.AddUserRoleAsync(user.Id, 4);
            await _roleWriteService.AddUserRoleAsync(user.Id, 2);
            await _roleWriteService.SaveAsync();
            if (!result.Success)
            {
                return new ErrorDataResult<User>(_language.FailureRegister);
            }
            return new SuccessDataResult<User>(_language.SuccessRegister);
        }

        public async Task<IResult> ResetPasswordAsync(User user, string oldPassword, string newPassword)
        {
            byte[] passwordHash, passwordSalt;

            if (!HashingHelper.VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
            {
                var errorModel = new ErrorResult("Eski şifreniz uyuşmuyor!");
                return errorModel;
            }
            if (HashingHelper.VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
            {
                var errorModel = new ErrorResult("Yeni şifreniz eski şifre ile aynı olamaz!");
                return errorModel;
            }

            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
            user = new FluentEntity<User>(user)
                .AddParameter(u => u.PasswordHash, passwordHash)
                .AddParameter(u => u.PasswordSalt, passwordSalt)
                .GetEntity();
            var result = _userWriteService.Update(user);
            await _userWriteService.SaveAsync();
            return result;
        }

        public async Task<IResult> UserExistsAsync(string email)
        {
            User user = (await _userReadService.GetByEmailAsync(email)).Data;
            if (user == null)
                return new SuccessResult(_language.UserNotFound);
            return new ErrorResult(_language.UserAlreadyExists);
        }
    }
}
