using System;
using System.Collections.Generic;
using System.Text;
using Azure.Messaging.ServiceBus;
using Conference.Application.EventBus;
using Microsoft.Extensions.Options;

namespace Conference.Infrastructure.ServiceBus;

internal class AzureServiceBusPublisherAdapter : IServiceBusPublisher
{
    private readonly ServiceBusSender _sender;

    public AzureServiceBusPublisherAdapter(ServiceBusClient client, IOptions<ServiceBusSettings> options)
    {
        var queueName = options.Value.QueueName;
        _sender = client.CreateSender(queueName);
    }

    public async Task PublishMessageAsync<T>(T message) where T : class
    {

        await _sender.SendMessageAsync(message);
    }
}