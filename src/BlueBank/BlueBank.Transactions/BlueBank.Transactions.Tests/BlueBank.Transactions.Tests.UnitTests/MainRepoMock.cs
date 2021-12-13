using BlueBank.Transactions.Core.AccountAggregates;
using BlueBank.Transactions.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace BlueBank.Transactions.Tests.UnitTests
{
    public class MainRepoMock
    {
        protected TransactionsDbContext _dbContext;

        protected static DbContextOptions<TransactionsDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<TransactionsDbContext>();
            builder.UseInMemoryDatabase("accountsmock")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public MainRepository<Account> GetAccountRepository()
        {
            var options = CreateNewContextOptions();
            var mockMediator = new Mock<IMediator>();

            _dbContext = new TransactionsDbContext(options, mockMediator.Object);
            return new MainRepository<Account>(_dbContext);
        }
    }
}
