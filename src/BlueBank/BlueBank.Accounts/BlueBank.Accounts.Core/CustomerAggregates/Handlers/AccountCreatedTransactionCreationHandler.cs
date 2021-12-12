using Ardalis.GuardClauses;
using BlueBank.Accounts.Core.CustomerAggregates.Events;
using BlueBank.Accounts.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Core.CustomerAggregates.Handlers
{
    public class AccountCreatedTransactionCreationHandler : INotificationHandler<AccountCreatedEvent>
    {
        private readonly ITransactionServiceClient _transactionsClient;

        // In a REAL app we should use some kind of queuing or even a service bus.
        public AccountCreatedTransactionCreationHandler(ITransactionServiceClient transactionsClient)
        {
            _transactionsClient = transactionsClient;
        }

        public Task Handle(AccountCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            if (domainEvent.InitialCredit > 0)
            {
                return _transactionsClient.CreateInitialTransactionAsync(domainEvent.Account.Id, domainEvent.InitialCredit);
            }

            return Task.CompletedTask;
        }
    }
}
