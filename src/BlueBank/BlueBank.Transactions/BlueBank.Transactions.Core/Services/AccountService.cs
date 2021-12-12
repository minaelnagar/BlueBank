using Ardalis.GuardClauses;
using BlueBank.SharedKernel.Data.Interfaces;
using BlueBank.SharedKernel.Services;
using BlueBank.Transactions.Core.AccountAggregates;
using BlueBank.Transactions.Core.AccountAggregates.Specifications;
using BlueBank.Transactions.Core.Interfaces;
using System.Threading.Tasks;

namespace BlueBank.Transactions.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _repository;

        public AccountService(IRepository<Account> repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> CreateNewTransaction(int accountId, decimal amount, TransactionType type)
        {
            Guard.Against.NegativeOrZero(accountId, nameof(accountId));
            Guard.Against.NegativeOrZero(amount, nameof(amount));

            var account = await _repository.GetBySpecAsync(new AccountByIdWithTransactionsSpec(accountId));

            if (account == null)
            {
                account = new Account(accountId);
                await _repository.AddAsync(account);
            }

            account.AddTransaction(new Transaction(amount, type));

            await _repository.SaveChangesAsync();

            return Result<bool>.Success();
        }

        public async Task<Account> GetAccount(int accountId)
        {
            return await _repository.GetBySpecAsync(new AccountByIdWithTransactionsSpec(accountId));
        }
    }
}
