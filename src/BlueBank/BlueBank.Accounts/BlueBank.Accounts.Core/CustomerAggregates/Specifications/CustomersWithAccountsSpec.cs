using Ardalis.Specification;

namespace BlueBank.Accounts.Core.CustomerAggregates.Specifications
{
    public class CustomersWithAccountsSpec : Specification<Customer>
    {
        public CustomersWithAccountsSpec()
        {
            Query
                .Include(customer => customer.Accounts);
        }
    }
}
