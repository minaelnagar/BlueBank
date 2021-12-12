using BlueBank.Accounts.Core.CustomerAggregates;

namespace BlueBank.Accounts.Api.ApiModels
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public AccountType Type { get; set; }
    }
}
