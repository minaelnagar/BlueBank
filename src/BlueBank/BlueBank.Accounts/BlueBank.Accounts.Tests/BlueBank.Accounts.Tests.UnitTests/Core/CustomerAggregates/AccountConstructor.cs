using BlueBank.Accounts.Core.CustomerAggregates;
using System.Linq;
using Xunit;

namespace BlueBank.Accounts.Tests.UnitTests.Core.CustomerAggregates
{
    public class AccountConstructor
    {
        private AccountType _testAccountType = AccountType.Current;
        private int _transactionsInitialCount = 0;
        private decimal _balanceInitialAmount = 0;

        private Account _testAccount = null;

        private Account CreateAccount()
        {
            return new Account(_testAccountType);
        }

        [Fact]
        public void InitializesType()
        {
            _testAccount = CreateAccount();

            Assert.Equal(_testAccountType, _testAccount.Type);
        }

        [Fact]
        public void InitializesTransactionsListToEmptyList()
        {
            _testAccount = CreateAccount();

            Assert.NotNull(_testAccount.Transactions);
            Assert.Equal(_transactionsInitialCount, _testAccount.Transactions.Count());
        }

        [Fact]
        public void InitializesBalance()
        {
            _testAccount = CreateAccount();

            Assert.Equal(_balanceInitialAmount, _testAccount.Balance);
        }
    }
}
