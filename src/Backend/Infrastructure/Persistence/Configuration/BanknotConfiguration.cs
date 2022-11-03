using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class BanknotConfiguration : IEntityTypeConfiguration<Banknot>
    {
        public void Configure(EntityTypeBuilder<Banknot> builder)
        {
            builder.Property(b => b.BankomatId).IsRequired();
            builder.Property(b => b.Amount).IsRequired();
            builder.Property(b => b.BanknotValue).IsRequired();
        }
    }
}
