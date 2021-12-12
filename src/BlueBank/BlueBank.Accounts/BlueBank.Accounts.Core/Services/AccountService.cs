using Ardalis.GuardClauses;
using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Core.CustomerAggregates.Specifications;
using BlueBank.Accounts.Core.Interfaces;
using BlueBank.SharedKernel.Data.Interfaces;
using BlueBank.SharedKernel.Services;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Customer> _repository;

        public AccountService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> OpenNewCurrentAccount(int customerId, decimal initialCredit)
        {
            Guard.Against.NegativeOrZero(customerId, nameof(customerId));

            var customer = await _repository.GetBySpecAsync(new CustomerByIdWithAccountsSpec(customerId));

            if (customer != null)
            {
                customer.AddAccount(new Account(AccountType.Current));
                await _repository.SaveChangesAsync();

                return Result<bool>.Success();
            }
            else
            {

                return Result<bool>.Fail(BusinessError.CustomerNotFound);
            }

        }
    }
}
