using Core.Entities.Concrete;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Entities.Concrete;
using CozProjectBackend.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUserReadService _userReadService;
        private readonly IUserWriteService _userWriteService;
        private readonly IQuestionCompleteWriteService _questionCompleteWriteService;
        public UsersController(IUserReadService userReadService, IUserWriteService userWriteService, IQuestionCompleteWriteService questionCompleteWriteService)
        {
            _userReadService = userReadService;
            _userWriteService = userWriteService;
            _questionCompleteWriteService = questionCompleteWriteService;
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
        public async Task<IActionResult> UpdateProfile(User user)
        {
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
            return Ok();
        }
    }
}
