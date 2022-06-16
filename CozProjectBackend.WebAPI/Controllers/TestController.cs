using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using FluentEntity_ConsoleApp.FEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash("123456", out passwordHash, out passwordSalt);
            User user = new FluentEntity<User>()
                .AddParameter(x => x.FirstName, "Emir")
                .AddParameter(x => x.LastName, "Gürbüz")
                .AddParameter(x => x.CreatedDate, DateTime.Now)
                .AddParameter(x => x.Score, 20)
                .AddParameter(x => x.EmailConfirmed, true)
                .AddParameter(x => x.PasswordHash, passwordHash)
                .GetEntity();
            return Ok(user);
        }
    }
}
