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

            var banknots = _context.Banknots.Where(b => b.BankomatId == request.BankomatId).ToList();

            var amountOf200bucks = banknots.Where(b => b.BanknotValue == 200).FirstOrDefault();
            var amountOf100bucks = banknots.Where(b => b.BanknotValue == 100).FirstOrDefault();
            var amountOf50bucks = banknots.Where(b => b.BanknotValue == 50).FirstOrDefault();
            var amountOf20bucks = banknots.Where(b => b.BanknotValue == 20).FirstOrDefault();
            var amountOf10bucks = banknots.Where(b => b.BanknotValue == 10).FirstOrDefault();

            var moneyLeftToWithdraw = request.AmountOfMoney;

            var output = new List<int>();

            while (bankAccount.Balance > moneyLeftToWithdraw && moneyLeftToWithdraw > 0 &&   amountOf200bucks.Amount >= 1)
            {
                if(moneyLeftToWithdraw < 200)
                {
                    break;
                }
                bankAccount.Balance -= 200;
                amountOf200bucks.Amount--;
                output.Add(200);
                moneyLeftToWithdraw -= 200;
            }

            while (bankAccount.Balance > moneyLeftToWithdraw && moneyLeftToWithdraw > 0 &&    amountOf100bucks.Amount >= 1)
            {
                if (moneyLeftToWithdraw < 100)
                {
                    break;
                }
                bankAccount.Balance -= 100;
                amountOf100bucks.Amount--;
                output.Add(100);
                moneyLeftToWithdraw -= 100;
            }

            while (bankAccount.Balance > moneyLeftToWithdraw && moneyLeftToWithdraw > 0 &&   amountOf50bucks.Amount >= 1)
            {
                if (moneyLeftToWithdraw < 50)
                {
                    break;
                }
                bankAccount.Balance -= 50;
                amountOf50bucks.Amount--;
                output.Add(50);
                moneyLeftToWithdraw -= 50;
            }

            while (bankAccount.Balance > moneyLeftToWithdraw && moneyLeftToWithdraw > 0 &&    amountOf20bucks.Amount >= 1)
            {
                if (moneyLeftToWithdraw < 20)
                {
                    break;
                }
                bankAccount.Balance -= 20;
                amountOf20bucks.Amount--;
                output.Add(20);
                moneyLeftToWithdraw -= 20;
            }

            while (bankAccount.Balance > moneyLeftToWithdraw && moneyLeftToWithdraw > 0 &&    amountOf10bucks.Amount >= 1)
            {
                if (moneyLeftToWithdraw < 10)
                {
                    break;
                }
                bankAccount.Balance -= 10;
                amountOf10bucks.Amount--;
                output.Add(10);
                moneyLeftToWithdraw -= 10;
            }

            if(moneyLeftToWithdraw > 0)
            {
                return new BadRequestObjectResult($"Not enough banknots in bankomat of Id {request.BankomatId}");
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


