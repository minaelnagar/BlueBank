using Ardalis.Specification;
using System.Linq;

namespace BlueBank.Accounts.Core.CustomerAggregates.Specifications
{
    public class CustomerByIdWithAccountsSpec : Specification<Customer>, ISingleResultSpecification
    {
        public CustomerByIdWithAccountsSpec(int customerId)
        {
            Query
                .Where(customer => customer.Id == customerId)
                .Include(customer => customer.Accounts);
        }
    }
}
