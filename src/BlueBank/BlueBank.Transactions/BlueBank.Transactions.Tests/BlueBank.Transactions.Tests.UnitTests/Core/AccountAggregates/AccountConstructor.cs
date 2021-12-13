using BlueBank.Transactions.Core.AccountAggregates;
using System;
using System.Linq;
using Xunit;

namespace BlueBank.Transactions.Tests.UnitTests.Core.CustomerAggregates
{
    public class AccountConstructor
    {
        private int _transactionsInitialCount = 0;
        private decimal _balanceInitialAmount = 0;
        private int _initialAccountId = 1;

        private Account _testAccount = null;

        private Account CreateAccount(int id)
        {
            return new Account(id);
        }

        [Fact]
        public void InitializesTransactionsListToEmptyList()
        {
            _testAccount = CreateAccount(_initialAccountId);

            Assert.NotNull(_testAccount.Transactions);
            Assert.Equal(_transactionsInitialCount, _testAccount.Transactions.Count());
        }

        [Fact]
        public void InitializesBalance()
        {
            _testAccount = CreateAccount(_initialAccountId);

            Assert.Equal(_balanceInitialAmount, _testAccount.Balance);
        }

        [Fact]
        public void ThrowsExceptionGivenNegativeAccountIdArgument()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => CreateAccount(-1));
        }

        [Fact]
        public void ThrowsExceptionGivenZeroAccountIdArgument()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => CreateAccount(0));
        }
    }
}
