using MediatR;
using System;

namespace BlueBank.SharedKernel.Data
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
