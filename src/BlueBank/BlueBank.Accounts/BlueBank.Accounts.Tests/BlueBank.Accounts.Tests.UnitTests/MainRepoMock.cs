using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace BlueBank.Accounts.Tests.UnitTests
{
    public class MainRepoMock
    {
        protected AccountsDbContext _dbContext;

        protected static DbContextOptions<AccountsDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AccountsDbContext>();
            builder.UseInMemoryDatabase("accountsmock")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public MainRepository<Customer> GetCustomerRepository()
        {
            var options = CreateNewContextOptions();
            var mockMediator = new Mock<IMediator>();

            _dbContext = new AccountsDbContext(options, mockMediator.Object);
            return new MainRepository<Customer>(_dbContext);
        }
    }
}
