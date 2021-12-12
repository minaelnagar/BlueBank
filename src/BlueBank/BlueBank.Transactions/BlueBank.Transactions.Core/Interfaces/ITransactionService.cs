using BlueBank.SharedKernel.Services;
using System.Threading.Tasks;

namespace BlueBank.Transactions.Core.Interfaces
{
    public interface ITransactionService
    {
        Task<Result<bool>> OpenNewCurrentAccount(int customerId, decimal initialCredit);
    }
}
