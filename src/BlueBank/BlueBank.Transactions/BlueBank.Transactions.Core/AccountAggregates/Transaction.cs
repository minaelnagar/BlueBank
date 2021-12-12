using Ardalis.GuardClauses;
using BlueBank.SharedKernel.Data;

namespace BlueBank.Transactions.Core.AccountAggregates
{
    public class Transaction : BaseEntity
    {
        public Transaction(decimal amount, TransactionType type)
        {
            Amount = Guard.Against.NegativeOrZero(amount, nameof(amount));
            Type = type;
        }

        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
    }
}
