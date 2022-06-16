using Core.Entities.Concrete;
using Core.Entities.FluentEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CozProjectBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var user = new FluentEntity<User>()
                .AddParameter(x => x.FirstName, "Emir");
            return Ok();
        }
    }
}
