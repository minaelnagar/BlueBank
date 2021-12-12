using BlueBank.SharedKernel.Data;

namespace BlueBank.Accounts.Core.CustomerAggregates.Events
{
    public class AccountCreatedEvent : BaseDomainEvent
    {
        public AccountCreatedEvent(Account account, decimal initialCredit)
        {
            Account = account;
            InitialCredit = initialCredit;
        }

        public Account Account { get; private set; }
        public decimal InitialCredit { get; private set; }
    }
}
