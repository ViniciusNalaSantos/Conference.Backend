using Azure.Messaging.ServiceBus;
using Conference.Application.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure.ServiceBus;
public class AzureServiceBusConsumerAdapter: BackgroundService
{
    private readonly ServiceBusProcessor _processor;
    private readonly MessageDispatcher _dispatcher;

    public AzureServiceBusConsumerAdapter(ServiceBusClient client, IOptions<ServiceBusSettings> options, MessageDispatcher dispatcher)
    {
        var queueName = options.Value.QueueName;
        _processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions { AutoCompleteMessages = false });

        _processor.ProcessMessageAsync += ProcessMessageAsync;
        _processor.ProcessErrorAsync += ProcessErrorAsync;

        _dispatcher = dispatcher;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _processor.StartProcessingAsync(stoppingToken);
    }

    private async Task ProcessMessageAsync(ProcessMessageEventArgs args)
    {
        try
        {
            var body = args.Message.Body.ToString();
            var eventType = args.Message.ApplicationProperties["EventType"]?.ToString();

            await _dispatcher.DispatchAsync(eventType!, body, args.CancellationToken);

            await args.CompleteMessageAsync(args.Message);
        }
        catch (Exception ex)
        {
            await args.DeadLetterMessageAsync(
                args.Message,
                "ProcessingFailed",
                ex.Message);
        }
    }

    private Task ProcessErrorAsync(ProcessErrorEventArgs args)
    {
        Console.WriteLine($"ServiceBus Error: {args.Exception}");
        return Task.CompletedTask;
    }
}
