using Ardalis.GuardClauses;
using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Core.CustomerAggregates.Specifications;
using BlueBank.Accounts.Core.Interfaces;
using BlueBank.SharedKernel.Data.Interfaces;
using BlueBank.SharedKernel.Services;
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

        public async Task<Result<bool>> OpenNewCurrentAccount(int customerId, decimal initialCredit)
        {
            Guard.Against.NegativeOrZero(customerId, nameof(customerId));

            var customer = await _repository.GetBySpecAsync(new CustomerByIdWithAccountsSpec(customerId));

            if (customer != null)
            {
                Result
            }
            else
            {
                Result.Fail(BusinessError.CustomerNotFound)
                return Result.
            }

        }
    }
}
