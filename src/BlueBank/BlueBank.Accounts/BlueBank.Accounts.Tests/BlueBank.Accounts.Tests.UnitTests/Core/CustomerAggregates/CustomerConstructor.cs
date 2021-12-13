using BlueBank.Accounts.Core.CustomerAggregates;
using System.Linq;
using Xunit;

namespace BlueBank.Accounts.Tests.UnitTests.Core.CustomerAggregates
{
    public class CustomerConstructor
    {
        private string _testName = "testName";
        private string _testSurename = "testSurename";
        private int _accuontsInitialCount = 0;

        private Customer _testCustomer = null;

        private Customer CreateCustomer()
        {
            return new Customer(_testName, _testSurename);
        }

        [Fact]
        public void InitializesName()
        {
            _testCustomer = CreateCustomer();

            Assert.Equal(_testName, _testCustomer.Name);
            Assert.Equal(_testSurename, _testCustomer.Surename);
        }

        [Fact]
        public void InitializesAccountsListToEmptyList()
        {
            _testCustomer = CreateCustomer();

            Assert.NotNull(_testCustomer.Accounts);
            Assert.Equal(_accuontsInitialCount, _testCustomer.Accounts.Count());
        }
    }
}
