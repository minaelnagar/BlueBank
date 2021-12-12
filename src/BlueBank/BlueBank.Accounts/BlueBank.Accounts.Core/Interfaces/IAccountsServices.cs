using BlueBank.SharedKernel.Services;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Core.Interfaces
{
    public interface IAccountsServices
    {
        Task<Result<bool>> OpenNewCurrentAccount(int customerId, decimal initialCredit);
    }
}
