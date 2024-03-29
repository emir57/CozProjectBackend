﻿using AutoMapper;
using Core.Dtos.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using CozProject.Business.Abstract;
using CozProject.Business.Abstract.Auth;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using CozProject.WebAPI.Hubs;
using FluentEntity_ConsoleApp.FEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers;

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
    private readonly ILanguageMessage _languageMessage;
    public UsersController(IUserReadService userReadService, IUserWriteService userWriteService, IQuestionCompleteWriteService questionCompleteWriteService, IHubContext<ScoreHub> scoreHub, IMapper mapper, IRoleWriteService roleWriteService, IRoleReadService roleReadService, IAuthService authService, ILanguageMessage languageMessage)
    {
        _userReadService = userReadService;
        _userWriteService = userWriteService;
        _questionCompleteWriteService = questionCompleteWriteService;
        _scoreHub = scoreHub;
        _mapper = mapper;
        _roleWriteService = roleWriteService;
        _roleReadService = roleReadService;
        _authService = authService;
        _languageMessage = languageMessage;
    }
    [HttpGet("getroles")]
    public async Task<IActionResult> GetRoles(int userId)
    {
        IDataResult<User> userResult = await _userReadService.GetByIdAsync(userId);
        if (userResult.Success is false)
        {
            return BadRequest(userResult);
        }
        List<Role> roles = await _userReadService.GetRolesAsync(userResult.Data);
        return Ok(roles.Select(r => r.Name));
    }

    [HttpPost("updateprofile")]
    public async Task<IActionResult> UpdateProfile(UpdateUserDto updateUserDto)
    {
        IDataResult<User> getUserResult = await _userReadService.GetByEmailAsync(updateUserDto.Email);
        if (getUserResult.Data is null)
        {
            return BadRequest(getUserResult);
        }
        User user = getUserResult.Data;
        if (HashingHelper.VerifyPasswordHash(updateUserDto.Password, user.PasswordHash, user.PasswordSalt) is false)
        {
            ErrorResult errorModel = new ErrorResult(_languageMessage.PasswordIsWrong);
            return BadRequest(errorModel);
        }

        user = new FluentEntity<User>(user)
            .AddParameter(u => u.FirstName, updateUserDto.FirstName)
            .AddParameter(u => u.LastName, updateUserDto.LastName)
            .Entity;
        IResult result = await _userWriteService.UpdateAsync(user);
        await _userWriteService.SaveAsync();

        if (result.Success is false)
            return BadRequest(result);
        return Ok(result);
    }
    [HttpPost("resetpassword")]
    public async Task<IActionResult> ResetPassword(UserResetPasswordDto userResetPasswordDto)
    {
        IDataResult<User> getUserResult = await _userReadService.GetByEmailAsync(userResetPasswordDto.Email);
        if (getUserResult.Data is null)
        {
            return BadRequest(getUserResult);
        }
        User user = getUserResult.Data;

        IResult result = await _authService.ResetPasswordAsync(user, userResetPasswordDto.OldPassword, userResetPasswordDto.NewPassword);
        if (result.Success is false)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("updatescore")]
    public async Task<IActionResult> UpdateScore(UpdateScoreModel scoreModel)
    {
        IDataResult<User> getUserResult = await _userReadService.GetByIdAsync(scoreModel.UserId);
        if (getUserResult.Success is false)
            return BadRequest(getUserResult);

        User user = getUserResult.Data;
        await updateUserScore(user, scoreModel.Score);

        QuestionComplete questionComplete = new FluentEntity<QuestionComplete>()
            .AddParameter(q => q.QuestionId, scoreModel.QuestionId)
            .AddParameter(q => q.Result, scoreModel.Result)
            .AddParameter(q => q.UserId, scoreModel.UserId)
            .Entity;
        await _questionCompleteWriteService.AddAsync(questionComplete);


        await _questionCompleteWriteService.SaveAsync();

        await _scoreHub.Clients.All.SendAsync("SendScore", user.Id, user.Score);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IDataResult<List<User>> result = await _userReadService.GetListAsync();
        if (result.Success is false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetById(int userId)
    {
        IDataResult<User> result = await _userReadService.GetByIdAsync(userId);
        if (result.Success is false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    [HttpPost("updateuseradmin")]
    public async Task<IActionResult> UpdateUserAdmin(UpdateUserAdminDto updateUserAdminDto)
    {
        IDataResult<User> getUserResult = await _userReadService.GetByIdAsync(updateUserAdminDto.Id);
        if (getUserResult.Success is false)
            BadRequest(getUserResult);

        User user = getUserResult.Data;
        user = updateUser(user, updateUserAdminDto);

        IResult result = await _userWriteService.UpdateAsync(user);
        await updateRoles(user, updateUserAdminDto.Roles);

        if (result.Success is false)
            return BadRequest(result);

        return Ok(result);
    }
    private async Task updateRoles(User user, List<UpdateRoleDto> roles)
    {
        await _userWriteService.SaveAsync();
        foreach (UpdateRoleDto role in roles)
        {
            if (role.Checked)
                await _roleWriteService.AddUserRoleAsync(user.Id, role.Id);
            else
                await _roleWriteService.RemoveUserRoleAsync(user.Id, role.Id);
        }
        await _roleWriteService.SaveAsync();
    }
    private static User updateUser(User user, UpdateUserAdminDto updatedUser)
    {
        return new FluentEntity<User>(user)
            .AddParameter(u => u.FirstName, updatedUser.FirstName)
            .AddParameter(u => u.LastName, updatedUser.LastName)
            .AddParameter(u => u.Email, updatedUser.Email)
            .AddParameter(u => u.EmailConfirmed, updatedUser.EmailConfirmed)
            .AddParameter(u => u.Score, updatedUser.Score)
            .AddParameter(u => u.ProfilePhotoUrl, updatedUser.ProfilePhotoUrl)
            .Entity;
    }

    [NonAction]
    private async Task updateUserScore(User user, int score)
    {
        user = new FluentEntity<User>(user)
            .AddParameter(u => u.Score, score)
            .Entity;
        await _userWriteService.UpdateAsync(user);
        await _userWriteService.SaveAsync();
    }
}
