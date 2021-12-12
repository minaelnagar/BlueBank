using BlueBank.Accounts.Core.CustomerAggregates;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Core.Interfaces
{
    public interface ITransactionServiceClient
    {
        Task CreateInitialTransactionAsync(int accountId, decimal amount);
        Task PopulateAccountDetailsAsync(Account account);
        Task PopulateAccountsDetailsAsync(Customer customer);
    }
}
