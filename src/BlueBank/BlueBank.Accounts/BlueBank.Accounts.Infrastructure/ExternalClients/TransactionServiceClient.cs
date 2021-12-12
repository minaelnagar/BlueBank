using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Core.Interfaces;
using BlueBank.Accounts.Infrastructure.ExternalClients.ExternalModels.TransactionsService;
using BlueBank.Accounts.Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Infrastructure.ExternalClients
{
    public class TransactionServiceClient : BaseClient, ITransactionServiceClient
    {
        private readonly ITransactionServiceSettings _serviceSettings;

        public TransactionServiceClient(ITransactionServiceSettings serviceSettings)
            : base(serviceSettings.BaseUrl)
        {
            _serviceSettings = serviceSettings;
        }

        public Task CreateInitialTransactionAsync(int accountId, decimal amount)
        {
            return PostAsync<string>(new CreateTransactionDTO() { AccountId = accountId, Amount = amount, Type = TransactionType.Credit }, _serviceSettings.CreateTransactionPath);
        }

        public async Task PopulateAccountDetailsAsync(Account account)
        {
            var accountResult = (await GetAsync<AccountDTO>(null, $"Accounts/{account.Id}")).Data;

            if (accountResult != null)
            {
                account.Balance = accountResult.Balance;

                if (accountResult.Transactions != null)
                {
                    account.Transactions = accountResult.Transactions.Select(a => new Transaction() { Amount = a.Amount, Type = a.Type }).ToList();
                }
            }
        }

        public async Task PopulateAccountsDetailsAsync(Customer customer)
        {
            foreach (var account in customer.Accounts)
            {
                await PopulateAccountDetailsAsync(account);
            }
        }
    }
}
