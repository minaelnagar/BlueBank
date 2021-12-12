using BlueBank.Accounts.Core.CustomerAggregates;
using System.Collections.Generic;

namespace BlueBank.Accounts.Api.ApiModels
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public AccountType Type { get; set; }

        public decimal Balance { get; set; }
        public IEnumerable<TransactionDTO> Transactions { get; set; } = new List<TransactionDTO>();
    }
}
