using BlueBank.SharedKernel.Data.Interfaces;
using BlueBank.Transactions.Core.AccountAggregates;
using BlueBank.Transactions.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BlueBank.Transactions.Tests.UnitTests.Core.Services
{
    public class AccountServiceCreateNewTransactionScenario
    {
        private readonly IRepository<Account> _repository;
        private AccountService _accountService;

        private int _initialAccountId = 1;
        private int _zeroAccountId = 0;
        private int _negativeAccountId = -1;
        private decimal _zeroInitialCredit = 0;
        private decimal _negativeInitialCredit = -1;
        private decimal _prositiveAmount = 100;

        private bool _didFail = true;

        private Account _testAccount = new Account(1);
        private int _initialTransactionsCount = 1;

        public AccountServiceCreateNewTransactionScenario()
        {
            _repository = new MainRepoMock().GetAccountRepository();
            _accountService = new AccountService(_repository);
        }

        [Fact]
        public async Task ThrowsExceptionGivenZeroAccountIdArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentException>(() => _accountService.CreateNewTransaction(_zeroAccountId, _zeroInitialCredit, TransactionType.Credit));
        }

        [Fact]
        public async Task ThrowsExceptionGivenNegativeAccountIdArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentException>(() => _accountService.CreateNewTransaction(_negativeAccountId, _zeroInitialCredit, TransactionType.Credit));
        }

        [Fact]
        public async Task ThrowsExceptionGivenZeroAmountArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentException>(() => _accountService.CreateNewTransaction(_initialAccountId, _zeroInitialCredit, TransactionType.Credit));
        }

        [Fact]
        public async Task ThrowsExceptionGivenNegativeAmountArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentException>(() => _accountService.CreateNewTransaction(_initialAccountId, _negativeInitialCredit, TransactionType.Credit));
        }

        [Fact]
        public async Task SuccessResultGivenNormalArguments()
        {
            await _repository.AddAsync(_testAccount);

            var result = await _accountService.CreateNewTransaction(_initialAccountId, _prositiveAmount, TransactionType.Credit);

            Assert.NotEqual(_didFail, result.DidFail);
        }

        [Fact]
        public async Task TransactionsCountEqualsOneGivenNormalArgument()
        {
            await _repository.AddAsync(_testAccount);

            var result = await _accountService.CreateNewTransaction(_initialAccountId, _prositiveAmount, TransactionType.Credit);

            Assert.Equal(_initialTransactionsCount, _testAccount.Transactions.Count());
        }
    }
}
