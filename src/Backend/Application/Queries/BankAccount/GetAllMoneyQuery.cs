using Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Queries.BankAccount
{

    public class GetAllMoneyQuery : IRequest<IActionResult>
    {
        public int BankAccountId { get; set; }
    }

    public class GetAllMoneyQueryHandler : IRequestHandler<GetAllMoneyQuery, IActionResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IBankomatRepository _bankRepository;
        private readonly ILogger _logger;

        public GetAllMoneyQueryHandler(IApplicationDbContext context, IBankomatRepository bankRepository, ILogger<GetAllMoneyQueryHandler> logger)
        {
            _context = context;
            _bankRepository = bankRepository;
            _logger = logger;
            _logger.LogDebug("GetAllMoneyQueryHandler created succesfully");
        }

        public async Task<IActionResult> Handle(GetAllMoneyQuery request, CancellationToken cancellationToken)
        {
            var test = await _context.BankAccounts.Where(ba => ba.BankAccountId == request.BankAccountId).AsNoTracking().FirstOrDefaultAsync();

            if(test == null)
            {
                _logger.LogError($"Account of Id {request.BankAccountId} doesn't exist");
            }

            return new OkObjectResult(test);
        }
    }


}
