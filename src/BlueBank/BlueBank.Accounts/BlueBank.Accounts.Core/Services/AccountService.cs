using Ardalis.GuardClauses;
using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Core.CustomerAggregates.Specifications;
using BlueBank.Accounts.Core.Interfaces;
using BlueBank.SharedKernel.Data.Interfaces;
using BlueBank.SharedKernel.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Customer> _repository;
        private readonly ITransactionServiceClient _transactionServiceClient;

        public AccountService(IRepository<Customer> repository, ITransactionServiceClient transactionServiceClient)
        {
            _repository = repository;
            _transactionServiceClient = transactionServiceClient;
        }

        public async Task<Customer> Get(int id, bool includeDetails = true)
        {
            var customer = await _repository.GetBySpecAsync(new CustomerByIdWithAccountsSpec(id) { });

            if (customer != null && includeDetails)
            {
                await PopulateAccountsDetails(customer);
            }

            return customer;
        }

        public async Task<List<Customer>> List(bool includeDetails = true)
        {
            var customers = await _repository.ListAsync(new CustomersWithAccountsSpec());

            if (includeDetails)
            {
                foreach (var customer in customers)
                {
                    await PopulateAccountsDetails(customer);
                }
            }

            return customers;
        }

        public async Task<Result<bool>> OpenNewCurrentAccount(int customerId, decimal initialCredit)
        {
            Guard.Against.NegativeOrZero(customerId, nameof(customerId));

            var customer = await _repository.GetBySpecAsync(new CustomerByIdWithAccountsSpec(customerId));

            if (customer != null)
            {
                customer.AddAccount(new Account(AccountType.Current), initialCredit);
                await _repository.SaveChangesAsync();

                return Result<bool>.Success();
            }
            else
            {
                return Result<bool>.Fail(BusinessError.CustomerNotFound);
            }
        }

        public async Task PopulateAccountDetails(Account account)
        {
            await _transactionServiceClient.PopulateAccountDetailsAsync(account);
        }

        public async Task PopulateAccountsDetails(Customer customer)
        {
            await _transactionServiceClient.PopulateAccountsDetailsAsync(customer);
        }
    }
}
