using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
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
        var json = JsonSerializer.Serialize(message);

        var azureMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(json))
        {
            ContentType = "application/json",
            Subject = typeof(T).Name,
            MessageId = Guid.NewGuid().ToString()
        };

        azureMessage.ApplicationProperties["EventType"] = typeof(T).FullName;

        await _sender.SendMessageAsync(azureMessage);
    }
}