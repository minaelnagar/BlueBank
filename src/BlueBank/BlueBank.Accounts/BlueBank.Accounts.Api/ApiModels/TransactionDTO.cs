using BlueBank.Accounts.Core.CustomerAggregates;

namespace BlueBank.Accounts.Api.ApiModels
{
    public class TransactionDTO
    {
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
    }
}
