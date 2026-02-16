using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Conference.Infrastructure.ServiceBus;
public sealed class MessageDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    public MessageDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task DispatchAsync(string eventType, string body, CancellationToken token)
    {
        var type = Type.GetType(eventType);

        if (type == null)
            throw new InvalidOperationException($"Unknown event type {eventType}");

        var @event = JsonSerializer.Deserialize(body, type);

        //var handlerType = typeof(IIntegrationEventHandler<>).MakeGenericType(type);
        //dynamic handler = _serviceProvider.GetRequiredService(handlerType);
        //await handler.HandleAsync((dynamic)@event, token);
    }
}
