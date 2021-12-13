using BlueBank.Transactions.Core.AccountAggregates;
using BlueBank.Transactions.Core.AccountAggregates.Specifications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BlueBank.Transactions.Tests.UnitTests.Core.CustomerAggregates
{
    public class AccountByIdWithTransactionsSpecFiltering
    {
        [Fact]
        public void FilterCollectionToOnlyReturnAccountWithSpecificId()
        {
            var account1 = new Account(1);
            var account2 = new Account(2);
            var account3 = new Account(3);

            var accounts = new List<Account>() { account1, account2, account3 };

            var spec = new AccountByIdWithTransactionsSpec(1);

            List<Account> filteredList = accounts
                .Where(spec.WhereExpressions.First().Compile())
                .ToList();

            Assert.Contains(account1, filteredList);
            Assert.DoesNotContain(account2, filteredList);
            Assert.DoesNotContain(account3, filteredList);
        }
    }
}
