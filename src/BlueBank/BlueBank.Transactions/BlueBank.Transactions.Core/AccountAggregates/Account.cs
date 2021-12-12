using Ardalis.GuardClauses;
using BlueBank.SharedKernel.Data;
using BlueBank.SharedKernel.Data.Interfaces;
using System.Collections.Generic;

namespace BlueBank.Transactions.Core.AccountAggregates
{
    public class Account : BaseEntity, IAggregateRoot
    {
        public Account(int id)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Balance = 0;
        }

        private List<Transaction> _transactions = new List<Transaction>();
        public IEnumerable<Transaction> Transactions => _transactions.AsReadOnly();

        public decimal Balance { get; private set; }

        public void AddTransaction(Transaction newTransaction)
        {
            Guard.Against.Null(newTransaction, nameof(newTransaction));
            _transactions.Add(newTransaction);

            Balance += newTransaction.Amount * (int)newTransaction.Type;
        }
    }
}
