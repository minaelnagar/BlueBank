using BlueBank.SharedKernel.Data;

namespace BlueBank.Accounts.Core.CustomerAggregates
{
    public class Account : BaseEntity
    {
        public Account(AccountType type)
        {
            Type = type;
        }

        public AccountType Type { get; private set; }
    }
}
