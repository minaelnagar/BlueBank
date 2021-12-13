using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Core.Interfaces;
using BlueBank.Accounts.Core.Services;
using BlueBank.SharedKernel.Data.Interfaces;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BlueBank.Accounts.Tests.UnitTests.Core.Services
{
    public class AccountServiceOpenNewCurrentAccountScenario
    {
        private readonly IRepository<Customer> _repository;
        private Mock<ITransactionServiceClient> _transactionsClientMock;
        private AccountService _accountService;

        private int _initialCustomerId = 1;
        private int _zeroCustomerId = 0;
        private int _negativeCustomerId = -1;
        private decimal _zeroInitialCredit = 0;

        private bool _didFail = true;

        private Customer _testCustomer = new Customer("testName", "testSurename") { Id = 1 };
        private int _initialAccountsCount = 1;

        public AccountServiceOpenNewCurrentAccountScenario()
        {
            _repository = new MainRepoMock().GetCustomerRepository();
            _transactionsClientMock = new Mock<ITransactionServiceClient>();
            _accountService = new AccountService(_repository, _transactionsClientMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenZeroCustomerIdArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentException>(() => _accountService.OpenNewCurrentAccount(_zeroCustomerId, _zeroInitialCredit));
        }

        [Fact]
        public async Task ThrowsExceptionGivenNegativeCustomerIdArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentException>(() => _accountService.OpenNewCurrentAccount(_negativeCustomerId, _zeroInitialCredit));
        }

        [Fact]
        public async Task FailResultGivenNonExistingCustomerIdArgument()
        {
            var result = await _accountService.OpenNewCurrentAccount(_initialCustomerId, _zeroInitialCredit);

            Assert.Equal(_didFail, result.DidFail);
        }

        [Fact]
        public async Task SuccessResultGivenExistingCustomerIdArgument()
        {
            await _repository.AddAsync(_testCustomer);

            var result = await _accountService.OpenNewCurrentAccount(_initialCustomerId, _zeroInitialCredit);

            Assert.NotEqual(_didFail, result.DidFail);
        }

        [Fact]
        public async Task AccountsCountEqualsOneGivenNonExistingCustomerIdArgument()
        {
            await _repository.AddAsync(_testCustomer);

            var result = await _accountService.OpenNewCurrentAccount(_initialCustomerId, _zeroInitialCredit);

            Assert.NotEqual(_initialAccountsCount, _testCustomer.Accounts.Count());
        }
    }
}
