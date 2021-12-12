using BlueBank.SharedKernel.Services;
using BlueBank.Transactions.Core.AccountAggregates;
using System.Threading.Tasks;

namespace BlueBank.Transactions.Core.Interfaces
{
    public interface IAccountService
    {
        Task<Result<bool>> CreateNewTransaction(int accountId, decimal amount, TransactionType type);
        Task<Account> GetAccount(int accountId);
    }
}
