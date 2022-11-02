using Application.Commands.BankAccounts.WithdrawMoney;
using Application.Queries.BankAccount;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("bank-account")]
    [ApiController]
    public class BankAccountController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllMoney(int id)
        {
            return await Mediator.Send(new GetAllMoneyQuery() { BankAccountId = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody] WithdrawMoneyCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
