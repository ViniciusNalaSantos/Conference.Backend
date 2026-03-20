using Conference.Application.EventBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure.ServiceBus;
public class DomainEventsDispatcher
{
    private readonly IServiceBusPublisher _serviceBus;
    public DomainEventsDispatcher(IServiceBusPublisher serviceBus)
    {
        _serviceBus = serviceBus;
    }
    public async Task DispatchAsync(IEnumerable<object> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            await _serviceBus.PublishMessageAsync(domainEvent);
        }
    }
}
