﻿using Ardalis.GuardClauses;
using BlueBank.SharedKernel.Data;
using BlueBank.SharedKernel.Data.Interfaces;
using System.Collections.Generic;

namespace BlueBank.Accounts.Core.CustomerAggregates

{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public Customer(string name, string surename)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Surename = Guard.Against.NullOrEmpty(surename, nameof(surename));
        }

        public string Name { get; private set; }
        public string Surename { get; private set; }

        private List<Account> _accounts = new List<Account>();
        public IEnumerable<Account> Accounts => _accounts.AsReadOnly();

        public void AddAccount(Account newAccount)
        {
            _accounts.Add(newAccount);

            //var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
            //Events.Add(newItemAddedEvent);
        }
    }
}
