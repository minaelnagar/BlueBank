using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Core.Interfaces;
using BlueBank.SharedKernel.Data.Interfaces;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Core.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly IRepository<Customer> _repository;

        public AccountsServices(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public Task<bool> OpenNewCurrentAccount(int customerId, decimal initialCredit)
        {

        }
    }
}
