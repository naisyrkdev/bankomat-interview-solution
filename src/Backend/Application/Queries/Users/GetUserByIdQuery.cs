using Application.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Queries.Users
{

    public class GetUserByIdQuery : IRequest<IActionResult>
    {
        public int UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IActionResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger _logger;

        public GetUserByIdQueryHandler(IApplicationDbContext context, ILogger<GetUserByIdQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogDebug("GetUserByIdQueryHandler created succesfully");
        }

        public async Task<IActionResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = new();

            try
            {
                user = await _context.Users.Where(u => u.UserId == request.UserId).Include(u => u.BankAccounts).AsNoTracking().FirstOrDefaultAsync();
                if(user == null)
                {
                    return new BadRequestObjectResult("User doesn't exist");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return new OkObjectResult(user);
        }
    }
}
