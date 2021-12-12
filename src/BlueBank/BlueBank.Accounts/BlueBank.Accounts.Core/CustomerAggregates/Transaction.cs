namespace BlueBank.Accounts.Core.CustomerAggregates
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
    }
}
