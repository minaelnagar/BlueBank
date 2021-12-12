using BlueBank.Transactions.Core.AccountAggregates;
using BlueBank.Transactions.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BlueBank.Transactions.Api
{
    public static class SeedData
    {
        public static readonly Account Account1 = new Account(1);
        public static readonly Transaction Transaction1 = new Transaction(20, TransactionType.Credit);

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new TransactionsDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TransactionsDbContext>>(), null))
            {
                // Look for any Accounts items.
                if (dbContext.Accounts.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);
            }
        }

        public static void PopulateTestData(TransactionsDbContext dbContext)
        {
            Account1.AddTransaction(Transaction1);
            dbContext.Accounts.Add(Account1);

            dbContext.SaveChanges();
        }
    }
}
