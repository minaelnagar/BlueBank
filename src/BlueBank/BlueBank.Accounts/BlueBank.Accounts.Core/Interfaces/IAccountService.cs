using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.SharedKernel.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Core.Interfaces
{
    public interface IAccountService
    {
        Task<Result<bool>> OpenNewCurrentAccount(int customerId, decimal initialCredit);
        Task PopulateAccountsDetails(Customer customer);
        Task PopulateAccountDetails(Account account);

        Task<Customer> Get(int id, bool includeDetails = true);
        Task<List<Customer>> List(bool includeDetails = true);
    }
}
