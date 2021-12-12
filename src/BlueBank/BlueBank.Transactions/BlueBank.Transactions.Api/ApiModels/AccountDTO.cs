using System.Collections.Generic;

namespace BlueBank.Transactions.Api.ApiModels
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<TransactionDTO> Transactions { get; set; } = new List<TransactionDTO>();
    }
}
