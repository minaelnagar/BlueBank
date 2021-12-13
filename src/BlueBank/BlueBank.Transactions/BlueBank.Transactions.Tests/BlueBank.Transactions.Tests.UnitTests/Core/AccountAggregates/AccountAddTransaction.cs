using BlueBank.Transactions.Core.AccountAggregates;
using System;
using Xunit;

namespace BlueBank.Transactions.Tests.UnitTests.Core.CustomerAggregates
{
    public class AccountAddTransaction
    {
        private Account _testAccount = new Account(1);
        private decimal _testTransactionCredit = 100;

        [Fact]
        public void AddTransactionToAccount()
        {
            var testTransaction = new Transaction(_testTransactionCredit, TransactionType.Credit);

            decimal balanceBefore = _testAccount.Balance;
            _testAccount.AddTransaction(testTransaction);

            Assert.Contains(testTransaction, _testAccount.Transactions);
            Assert.Equal(balanceBefore + _testTransactionCredit, _testAccount.Balance);
        }

        [Fact]
        public void ThrowsExceptionGivenNullTransaction()
        {
            Action action = () => _testAccount.AddTransaction(null);

            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("newTransaction", ex.ParamName);
        }
    }
}
