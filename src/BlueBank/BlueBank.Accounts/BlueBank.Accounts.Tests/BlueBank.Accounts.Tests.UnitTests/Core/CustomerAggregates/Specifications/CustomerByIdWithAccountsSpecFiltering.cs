using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Core.CustomerAggregates.Specifications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BlueBank.Accounts.Tests.UnitTests.Core.CustomerAggregates
{
    public class CustomerByIdWithAccountsSpecFiltering
    {
        private string _testName = "testName";
        private string _testSurename = "testSurename";

        [Fact]
        public void FilterCollectionToOnlyReturnCustomerWithSpecificId()
        {
            var customer1 = new Customer(_testName, _testSurename) { Id = 1 };
            var customer2 = new Customer(_testName, _testSurename) { Id = 2 };
            var customer3 = new Customer(_testName, _testSurename) { Id = 3 };

            var customers = new List<Customer>() { customer1, customer2, customer3 };

            var spec = new CustomerByIdWithAccountsSpec(1);

            List<Customer> filteredList = customers
                .Where(spec.WhereExpressions.First().Compile())
                .ToList();

            Assert.Contains(customer1, filteredList);
            Assert.DoesNotContain(customer2, filteredList);
            Assert.DoesNotContain(customer3, filteredList);
        }
    }
}
