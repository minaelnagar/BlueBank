using BlueBank.SharedKernel;
using System;

namespace BlueBank.Accounts.Core.CustomerAggregates
{
    public class Account : BaseEntity
    {
        public Account(AccountType type)
        {
            Type = type;
            CreationDate = DateTime.UtcNow;
        }

        public AccountType Type { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
