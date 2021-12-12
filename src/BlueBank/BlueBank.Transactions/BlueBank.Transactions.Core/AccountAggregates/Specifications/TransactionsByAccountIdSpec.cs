using Ardalis.Specification;
using System.Linq;

namespace BlueBank.Transactions.Core.TransactionAggregates.Specifications
{
    public class TransactionsByAccountIdSpec : Specification<Transaction>
    {
        public TransactionsByAccountIdSpec(int accountId)
        {
            Query
                .Where(transaction => transaction.AccountId == accountId);
        }
    }
}
