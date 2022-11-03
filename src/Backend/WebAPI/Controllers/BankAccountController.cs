using Application.Commands.BankAccounts.WithdrawMoney;
using Application.Queries.BankAccounts;
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
            return await Mediator.Send(new GetBankAccountByIdQuery() { BankAccountId = id});
        }

        [Route("withdraw-money")]
        [HttpPost]
        public async Task<IActionResult> WithdrawMoney([FromBody] WithdrawMoneyCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
