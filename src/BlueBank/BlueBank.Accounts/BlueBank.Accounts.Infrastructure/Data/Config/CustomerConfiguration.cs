using BlueBank.Accounts.Core.CustomerAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueBank.Accounts.Infrastructure.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired();

            builder.Property(t => t.Surename)
                .IsRequired();
        }
    }
}
