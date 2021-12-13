using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Core.CustomerAggregates.Events;
using System;
using System.Linq;
using Xunit;

namespace BlueBank.Accounts.Tests.UnitTests.Core.CustomerAggregates
{
    public class CustomerAddAccount
    {
        private Customer _testCustomer = new Customer("testName", "testSurename");
        private decimal _testInitialCredit = 0;

        [Fact]
        public void AddAccountToCustomer()
        {
            var _testAccount = new Account(AccountType.Current);

            _testCustomer.AddAccount(_testAccount, _testInitialCredit);

            Assert.Contains(_testAccount, _testCustomer.Accounts);
            Assert.Single(_testCustomer.Events);
            Assert.IsType<AccountCreatedEvent>(_testCustomer.Events.First());
        }

        [Fact]
        public void ThrowsExceptionGivenNullAccount()
        {
            Action action = () => _testCustomer.AddAccount(null, 0);

            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("newAccount", ex.ParamName);
        }
    }
}
