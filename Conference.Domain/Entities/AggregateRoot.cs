using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Entities;
public abstract class AggregateRoot
{
    private readonly List<object> _domainEvents = new();
    public IReadOnlyCollection<object> DomainEvents => _domainEvents;

    public void AddDomainEvent(object domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void ClearDomainEvent()
    {
        _domainEvents.Clear();
    }
}
