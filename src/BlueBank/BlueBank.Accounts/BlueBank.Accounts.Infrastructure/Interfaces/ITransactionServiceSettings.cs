namespace BlueBank.Accounts.Infrastructure.Interfaces
{
    public interface ITransactionServiceSettings
    {
        string BaseUrl { get; }
        string CreateTransactionPath { get; }
    }
}
