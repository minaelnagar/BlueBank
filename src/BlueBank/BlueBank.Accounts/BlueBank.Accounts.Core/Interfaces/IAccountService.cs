using BlueBank.SharedKernel.Services;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Core.Interfaces
{
    public interface IAccountService
    {
        Task<Result<bool>> OpenNewCurrentAccount(int customerId, decimal initialCredit);
    }
}
