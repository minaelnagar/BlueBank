using BlueBank.Accounts.Core.CustomerAggregates;
using System.Collections.Generic;

namespace BlueBank.Accounts.Api.ApiModels
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public IEnumerable<Account> Accounts { get; set; } = new List<Account>();
    }
}
