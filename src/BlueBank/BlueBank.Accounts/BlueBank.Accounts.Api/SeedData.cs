using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BlueBank.Accounts.Api
{
    public static class SeedData
    {
        public static readonly Customer Customer1 = new Customer("Mina", "Elnagar");
        public static readonly Customer Customer2 = new Customer("Tim", "Beek");
        public static readonly Account Account1 = new Account(AccountType.Current);

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AccountsDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AccountsDbContext>>(), null))
            {
                // Look for any Accounts items.
                if (dbContext.Accounts.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);
            }
        }

        public static void PopulateTestData(AccountsDbContext dbContext)
        {
            Customer1.AddAccount(Account1, 0);
            dbContext.Customers.Add(Customer1);
            dbContext.Customers.Add(Customer2);

            dbContext.SaveChanges();
        }
    }
}
