using Application.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Queries.BankAccounts
{

    public class GetBankAccountByIdQuery : IRequest<IActionResult>
    {
        public int BankAccountId { get; set; }
    }

    public class GetBankAccountByIdQueryHandler : IRequestHandler<GetBankAccountByIdQuery, IActionResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger _logger;

        public GetBankAccountByIdQueryHandler(IApplicationDbContext context, ILogger<GetBankAccountByIdQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogDebug("GetBankAccountByIdQueryHandler created succesfully");
        }

        public async Task<IActionResult> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
        {
            BankAccount bankAccount = new();

            try
            {
                bankAccount = await _context.BankAccounts.Where(ba => ba.BankAccountId == request.BankAccountId).Include(ba => ba.User).AsNoTracking().FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new BadRequestObjectResult("An error has occured");
            }

            if(bankAccount == null)
            {
                _logger.LogError($"Account of Id {request.BankAccountId} doesn't exist");
            }

            return new OkObjectResult(bankAccount);
        }
    }
}
