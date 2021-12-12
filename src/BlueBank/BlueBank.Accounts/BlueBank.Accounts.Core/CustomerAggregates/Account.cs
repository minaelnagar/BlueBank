using BlueBank.SharedKernel.Data;
using System.Collections.Generic;

namespace BlueBank.Accounts.Core.CustomerAggregates
{
    public class Account : BaseEntity
    {
        public Account(AccountType type)
        {
            Type = type;
        }

        public AccountType Type { get; private set; }

        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
