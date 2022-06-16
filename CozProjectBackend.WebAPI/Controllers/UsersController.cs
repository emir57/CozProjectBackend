using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Abstract.Auth;
using CozProjectBackend.Entities.Concrete;
using CozProjectBackend.Entities.Dto;
using CozProjectBackend.WebAPI.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IHubContext<ScoreHub> _scoreHub;
        private readonly IUserReadService _userReadService;
        private readonly IUserWriteService _userWriteService;
        private readonly IQuestionCompleteWriteService _questionCompleteWriteService;
        private readonly IRoleWriteService _roleWriteService;
        private readonly IRoleReadService _roleReadService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public UsersController(IUserReadService userReadService, IUserWriteService userWriteService, IQuestionCompleteWriteService questionCompleteWriteService, IHubContext<ScoreHub> scoreHub, IMapper mapper, IRoleWriteService roleWriteService, IRoleReadService roleReadService, IAuthService authService)
        {
            _userReadService = userReadService;
            _userWriteService = userWriteService;
            _questionCompleteWriteService = questionCompleteWriteService;
            _scoreHub = scoreHub;
            _mapper = mapper;
            _roleWriteService = roleWriteService;
            _roleReadService = roleReadService;
            _authService = authService;
        }
        [HttpGet("getroles")]
        public async Task<IActionResult> GetRoles(int userId)
        {
            IDataResult<User> userResult = await _userReadService.GetByIdAsync(userId);
            if (!userResult.Success)
            {
                return BadRequest(userResult);
            }
            List<Role> roles = await _userReadService.GetRolesAsync(userResult.Data);
            return Ok(roles.Select(r => r.Name));
        }

        [HttpPost("updateprofile")]
        public async Task<IActionResult> UpdateProfile(UpdateUserDto updateUserDto)
        {
            var getUser = await _userReadService.GetByEmailAsync(updateUserDto.Email);
            if (getUser.Data == null)
            {
                return BadRequest(getUser);
            }
            User user = getUser.Data;
            if (!HashingHelper.VerifyPasswordHash(updateUserDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                var errorModel = new ErrorResult("Şifre Yanlış!");
                return BadRequest(errorModel);
            }
            //TODO: refactoring
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            IResult result = _userWriteService.Update(user);
            await _userWriteService.SaveAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDto userResetPasswordDto)
        {
            var getUser = await _userReadService.GetByEmailAsync(userResetPasswordDto.Email);
            if (getUser.Data == null)
            {
                return BadRequest(getUser);
            }
            var user = getUser.Data;

            var result = await _authService.ResetPasswordAsync(user, userResetPasswordDto.OldPassword, userResetPasswordDto.NewPassword);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("updatescore")]
        public async Task<IActionResult> UpdateScore(UpdateScoreModel scoreModel)
        {
            var getUserResult = await _userReadService.GetByIdAsync(scoreModel.UserId);
            if (!getUserResult.Success)
            {
                return BadRequest(getUserResult);
            }
            var user = getUserResult.Data;
            user.Score += scoreModel.Score;
            _userWriteService.Update(user);
            await _questionCompleteWriteService.AddAsync(new QuestionComplete
            {
                QuestionId = scoreModel.QuestionId,
                Result = scoreModel.Result,
                UserId = scoreModel.UserId
            });
            await _userWriteService.SaveAsync();
            await _questionCompleteWriteService.SaveAsync();
            await _scoreHub.Clients.All.SendAsync("SendScore", user.Id, user.Score);
            return Ok();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userReadService.GetListAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int userId)
        {
            var result = await _userReadService.GetByIdAsync(userId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("updateuseradmin")]
        public async Task<IActionResult> UpdateUserAdmin(UpdateUserAdminDto updateUserAdminDto)
        {
            var getUserResult = await _userReadService.GetByIdAsync(updateUserAdminDto.Id);
            if (!getUserResult.Success)
                BadRequest(getUserResult);

            var user = getUserResult.Data;
            user = updateUser(user, updateUserAdminDto);

            var result = _userWriteService.Update(user);
            await updateRoles(user, updateUserAdminDto.Roles);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        private async Task updateRoles(User user, List<UpdateRoleDto> roles)
        {
            await _userWriteService.SaveAsync();
            foreach (var role in roles)
            {
                if (role.Checked)
                    await _roleWriteService.AddUserRoleAsync(user.Id, role.Id);
                else
                    await _roleWriteService.RemoveUserRoleAsync(user.Id, role.Id);
            }
            await _roleWriteService.SaveAsync();
        }
        private User updateUser(User user, UpdateUserAdminDto updatedUser)
        {
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.EmailConfirmed = updatedUser.EmailConfirmed;
            user.Score = updatedUser.Score;
            user.ProfilePhotoUrl = updatedUser.ProfilePhotoUrl;
            return user;
        }
    }
}
