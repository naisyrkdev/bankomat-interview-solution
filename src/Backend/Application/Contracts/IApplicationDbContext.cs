using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; }

        public DbSet<BankAccount> BankAccounts { get; }

        public DbSet<Bankomat> Bankomats { get; }

        public DbSet<Banknot> Banknots { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
