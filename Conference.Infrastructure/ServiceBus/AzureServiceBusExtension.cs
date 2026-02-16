using Azure.Messaging.ServiceBus;
using Conference.Application.EventBus;
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

        services.AddScoped<IServiceBusPublisher, AzureServiceBusPublisherAdapter>();
    }
}

