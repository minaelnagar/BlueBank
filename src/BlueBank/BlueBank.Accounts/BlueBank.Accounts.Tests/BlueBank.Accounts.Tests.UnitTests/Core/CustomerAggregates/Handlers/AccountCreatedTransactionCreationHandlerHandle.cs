using BlueBank.Accounts.Core.CustomerAggregates;
using BlueBank.Accounts.Core.CustomerAggregates.Events;
using BlueBank.Accounts.Core.CustomerAggregates.Handlers;
using BlueBank.Accounts.Core.Interfaces;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BlueBank.Accounts.Tests.UnitTests.Core.CustomerAggregates.Handlers
{
    public class AccountCreatedTransactionCreationHandlerHandle
    {
        private AccountCreatedTransactionCreationHandler _handler;
        private Mock<ITransactionServiceClient> _transactionsClientMock;
        private decimal _nonZeroInitialCredit = 10;
        private decimal _zeroInitialCredit = 0;

        public AccountCreatedTransactionCreationHandlerHandle()
        {
            _transactionsClientMock = new Mock<ITransactionServiceClient>();
            _handler = new AccountCreatedTransactionCreationHandler(_transactionsClientMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task CreateInitialTransactionGivenEventInstanceForNonZeroInitialCredit()
        {
            await _handler.Handle(new AccountCreatedEvent(new Account(AccountType.Current), _nonZeroInitialCredit), CancellationToken.None);

            _transactionsClientMock.Verify(sender => sender.CreateInitialTransactionAsync(It.IsAny<int>(), It.IsAny<decimal>()), Times.Once);
        }

        [Fact]
        public async Task DontCreateInitialTransactionGivenEventInstanceForZeroInitialCredit()
        {
            await _handler.Handle(new AccountCreatedEvent(new Account(AccountType.Current), _zeroInitialCredit), CancellationToken.None);

            _transactionsClientMock.Verify(sender => sender.CreateInitialTransactionAsync(It.IsAny<int>(), It.IsAny<decimal>()), Times.Never);
        }
    }
}
