﻿using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using CozProjectBackend.Business.Abstract;
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
        private readonly IMapper _mapper;
        public UsersController(IUserReadService userReadService, IUserWriteService userWriteService, IQuestionCompleteWriteService questionCompleteWriteService, IHubContext<ScoreHub> scoreHub, IMapper mapper, IRoleWriteService roleWriteService, IRoleReadService roleReadService)
        {
            _userReadService = userReadService;
            _userWriteService = userWriteService;
            _questionCompleteWriteService = questionCompleteWriteService;
            _scoreHub = scoreHub;
            _mapper = mapper;
            _roleWriteService = roleWriteService;
            _roleReadService = roleReadService;
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
            byte[] passwordHash, passwordSalt;
            var getUser = await _userReadService.GetByEmailAsync(userResetPasswordDto.Email);
            if (getUser.Data == null)
            {
                return BadRequest(getUser);
            }

            var user = getUser.Data;
            if (!HashingHelper.VerifyPasswordHash(userResetPasswordDto.OldPassword, user.PasswordHash, user.PasswordSalt))
            {
                var errorModel = new ErrorResult("Eski şifreniz uyuşmuyor!");
                return BadRequest(errorModel);
            }
            if (HashingHelper.VerifyPasswordHash(userResetPasswordDto.NewPassword, user.PasswordHash, user.PasswordSalt))
            {
                var errorModel = new ErrorResult("Yeni şifreniz eski şifre ile aynı olamaz!");
                return BadRequest(errorModel);
            }

            HashingHelper.CreatePasswordHash(userResetPasswordDto.NewPassword, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var result = _userWriteService.Update(user);
            await _userWriteService.SaveAsync();

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
            {
                BadRequest(getUserResult);
            }
            //TODO: refactoring;
            var user = getUserResult.Data;
            user.FirstName = updateUserAdminDto.FirstName;
            user.LastName = updateUserAdminDto.LastName;
            user.Email = updateUserAdminDto.Email;
            user.EmailConfirmed = updateUserAdminDto.EmailConfirmed;
            user.Score = updateUserAdminDto.Score;
            user.ProfilePhotoUrl = updateUserAdminDto.ProfilePhotoUrl;
            var result = _userWriteService.Update(user);

            updateUserAdminDto.Roles.ForEach(async role =>
            {
                var getRole = await _roleReadService.GetByIdAsync(role.Id, tracking: false);
                if (role.Checked)
                    if (!(await _roleReadService.IsInRole(user, getRole.Data)).Success)
                    {
                        await _roleWriteService.AddAsync(getRole.Data);
                    }
                else
                    _roleWriteService.Delete(getRole.Data);
            });
            await _roleWriteService.SaveAsync();
            await _userWriteService.SaveAsync();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
