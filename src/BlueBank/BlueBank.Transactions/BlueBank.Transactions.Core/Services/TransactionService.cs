using Ardalis.GuardClauses;
using BlueBank.SharedKernel.Data.Interfaces;
using BlueBank.SharedKernel.Services;
using BlueBank.Transactions.Core.Interfaces;
using BlueBank.Transactions.Core.TransactionAggregates;
using System.Threading.Tasks;

namespace BlueBank.Transactions.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _repository;

        public TransactionService(IRepository<Transaction> repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> AddNewTransaction(int accountId, decimal amount, TransactionType type)
        {
            Guard.Against.NegativeOrZero(accountId, nameof(accountId));
            Guard.Against.NegativeOrZero(amount, nameof(amount));

            var transaction = new Transaction(accountId, amount, type);

            transaction.Events.Add()

        }
    }
}
