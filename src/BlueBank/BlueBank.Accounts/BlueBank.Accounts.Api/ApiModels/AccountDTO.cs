using BlueBank.Accounts.Core.CustomerAggregates;
using System;

namespace BlueBank.Accounts.Api.ApiModels
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public AccountType Type { get; private set; }
        public DateTime CreationDate { get; set; }

    }
}
