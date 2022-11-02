using Application.Contracts;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Bankomat> Bankomats { get; set; }

        public DbSet<Banknot> Banknots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                FirstName = "Jan",
                LastName = "Kowalski"
            }
            );

            builder.Entity<BankAccount>().HasData(
                new BankAccount
                {
                    BankAccountId = 1,
                    UserId = 1,
                    Balance = 7650
                }
            );

            builder.Entity<Bankomat>().HasData(
                new Bankomat
                {
                    BankomatId = 1
                }
            );

            builder.Entity<Banknot>().HasData(
             new Banknot
             {
                 BanknotId = 1,
                 BankomatId = 1,
                 Amount = 5,
                 BanknotValue = 200
             },
              new Banknot
              {
                  BanknotId = 2,
                  BankomatId = 1,
                  Amount = 5,
                  BanknotValue = 100
              },
              new Banknot
              {
                  BanknotId = 3,
                  BankomatId = 1,
                  Amount = 5,
                  BanknotValue = 50
              },
              new Banknot
              {
                  BanknotId = 4,
                  BankomatId = 1,
                  Amount = 5,
                  BanknotValue = 20
              },
              new Banknot
              {
                  BanknotId = 5,
                  BankomatId = 1,
                  Amount = 5,
                  BanknotValue = 10
              }
         );

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
