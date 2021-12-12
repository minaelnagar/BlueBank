using Ardalis.GuardClauses;
using BlueBank.SharedKernel.Data;
using BlueBank.SharedKernel.Data.Interfaces;

namespace BlueBank.Transactions.Core.AccountAggregates
{
    public class Transaction : BaseEntity, IAggregateRoot
    {
        public Transaction(int accountId, decimal amount, TransactionType type)
        {
            AccountId = Guard.Against.NegativeOrZero(accountId, nameof(accountId));
            amount = Guard.Against.NegativeOrZero(amount, nameof(amount));
            Type = type;
        }

        public int AccountId { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
    }
}
