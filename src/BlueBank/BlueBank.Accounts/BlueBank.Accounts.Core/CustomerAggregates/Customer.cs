using Ardalis.GuardClauses;
using BlueBank.SharedKernel;
using BlueBank.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace BlueBank.Accounts.Core.CustomerAggregates

{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public Customer(string name, string surename)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Surename = Guard.Against.NullOrEmpty(surename, nameof(surename));
            CreationDate = DateTime.UtcNow;
        }

        public string Name { get; private set; }
        public string Surename { get; private set; }
        public DateTime CreationDate { get; private set; }

        private List<Account> _acounts = new List<Account>();
        public IEnumerable<Account> Accounts => _acounts.AsReadOnly();

        public void AddAccount(Account newAccount)
        {
            _acounts.Add(newAccount);

            //var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
            //Events.Add(newItemAddedEvent);
        }
    }
}
