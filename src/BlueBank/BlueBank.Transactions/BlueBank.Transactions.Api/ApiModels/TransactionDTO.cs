using BlueBank.Transactions.Core.AccountAggregates;

namespace BlueBank.Transactions.Api.ApiModels
{
    public class TransactionDTO
    {
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
    }
}
