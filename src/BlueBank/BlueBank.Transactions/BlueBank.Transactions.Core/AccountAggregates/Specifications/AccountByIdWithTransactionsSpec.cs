using Ardalis.Specification;
using System.Linq;

namespace BlueBank.Transactions.Core.AccountAggregates.Specifications
{
    public class AccountByIdWithTransactionsSpec : Specification<Account>, ISingleResultSpecification
    {
        public AccountByIdWithTransactionsSpec(int accountId)
        {
            Query
                .Where(account => account.Id == accountId)
                .Include(account => account.Transactions);
        }
    }
}
