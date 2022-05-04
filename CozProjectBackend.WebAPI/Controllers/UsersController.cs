using AutoMapper;
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
        private readonly IMapper _mapper;
        public UsersController(IUserReadService userReadService, IUserWriteService userWriteService, IQuestionCompleteWriteService questionCompleteWriteService, IHubContext<ScoreHub> scoreHub, IMapper mapper)
        {
            _userReadService = userReadService;
            _userWriteService = userWriteService;
            _questionCompleteWriteService = questionCompleteWriteService;
            _scoreHub = scoreHub;
            _mapper = mapper;
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
    }
}
