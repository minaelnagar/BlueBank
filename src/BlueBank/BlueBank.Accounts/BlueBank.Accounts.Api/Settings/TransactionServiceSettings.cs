using BlueBank.Accounts.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BlueBank.Accounts.Api.Settings
{
    public class TransactionServiceSettings : ITransactionServiceSettings
    {
        private readonly IConfiguration _config;

        public TransactionServiceSettings(IConfiguration config)
        {
            _config = config;
        }

        public string BaseUrl => _config.GetValue<string>("TransactionService:BaseUrl");

        public string CreateTransactionPath => _config.GetValue<string>("TransactionService:CreateTransactionPath");

        public string AccountsPath => _config.GetValue<string>("TransactionService:AccountsPath");
    }
}
