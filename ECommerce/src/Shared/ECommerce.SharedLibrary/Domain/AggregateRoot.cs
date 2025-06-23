﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedLibrary.Domain
{
    public abstract class AggregateRoot<T> : Entity<T>, IAggregateRoot where T : IEquatable<T>
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void ClearDomainEvents() => _domainEvents.Clear();
        

        protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);


    }
}
