using Azure.Messaging.ServiceBus;
using Conference.Application.EventBus;
using Conference.Application.Handlers;
using Conference.Application.Messages;
using Conference.Application.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Conference.WebApi")]

namespace Conference.Infrastructure.ServiceBus;
internal static class AzureServiceBusExtension
{
    public static void AddAzureServiceBusService(this IServiceCollection services)
    {
        services.AddSingleton(sp =>
        {
            var options = sp.GetRequiredService<IOptions<ServiceBusSettings>>().Value;
            return new ServiceBusClient(options.ConnectionString);
        });

        services.AddSingleton<IServiceBusPublisher, AzureServiceBusPublisherAdapter>();
        services.AddSingleton<MessageDispatcher, MessageDispatcher>();
        services.Scan(scan => scan
            .FromApplicationDependencies()
            .AddClasses(classes => classes.AssignableTo(typeof(IServiceBusMessageHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
    }
}

