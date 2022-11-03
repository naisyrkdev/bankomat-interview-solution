using Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("users")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllMoney(int id)
        {
            return await Mediator.Send(new GetUserByIdQuery() { UserId = id });
        }
    }
}
