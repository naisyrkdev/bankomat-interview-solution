using Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Commands.BankAccounts.WithdrawMoney
{
    public class WithdrawMoneyCommand : IRequest<IActionResult>
    {
        public int BankAccountId { get; set; }
        public int BankomatId { get; set; }
        public int AmountOfMoney { get; set; }
    }

    public class WithdrawMoneyCommandHandler : IRequestHandler<WithdrawMoneyCommand, IActionResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger _logger;

        public WithdrawMoneyCommandHandler(IApplicationDbContext context, ILogger<WithdrawMoneyCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogDebug("WithdrawMoneyCommandHandler created succesfully");
        }

        public async Task<IActionResult> Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            var bankAccount = _context.BankAccounts.Where(b => b.BankAccountId == request.BankomatId).FirstOrDefault();
            var bankomat = _context.Bankomats.Where(b => b.BankomatId == request.BankomatId).FirstOrDefault();

            var banknotsss = _context.Banknots.Where(b => b.BankomatId == request.BankomatId).ToList();

            var amountOf200bucks = banknotsss.Where(b => b.BanknotValue == 200).FirstOrDefault();
            var amountOf100bucks = banknotsss.Where(b => b.BanknotValue == 100).FirstOrDefault();
            var amountOf50bucks = banknotsss.Where(b => b.BanknotValue == 50).FirstOrDefault();
            var amountOf20bucks = banknotsss.Where(b => b.BanknotValue == 20).FirstOrDefault();
            var amountOf10bucks = banknotsss.Where(b => b.BanknotValue == 10).FirstOrDefault();

            var moneyLeftToWithdraw = request.AmountOfMoney;

            var output = new List<int>();

            while (bankAccount.Balance > moneyLeftToWithdraw && moneyLeftToWithdraw > 0 && amountOf200bucks.Amount >= 1)
            {
                bankAccount.Balance -= 200;
                amountOf200bucks.Amount--;
                output.Add(200);
                moneyLeftToWithdraw -= 200;
            }

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new BadRequestObjectResult("An error has occured.");
            }


            return new OkObjectResult(output);
        }
    }
}


