using BlueBank.Accounts.Core.CustomerAggregates;

namespace BlueBank.Accounts.Infrastructure.ExternalClients.ExternalModels.TransactionsService
{
    public class TransactionDTO
    {
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
    }
}
