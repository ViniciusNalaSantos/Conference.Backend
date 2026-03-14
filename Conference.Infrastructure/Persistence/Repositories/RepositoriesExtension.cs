using Conference.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Conference.WebApi")]

namespace Conference.Infrastructure.Persistence.Repositories;

internal static class RepositoriesExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        var assembly = typeof(IRepository).Assembly;

        var implementations = assembly.GetTypes()
            .Where(t => !t.IsInterface && !t.IsAbstract && typeof(IRepository).IsAssignableFrom(t))

        foreach (var implementation in implementations)
        {
            var interfaces = implementation.GetInterfaces()
                .Where(i => i != typeof(IRepository));

            foreach (var service in interfaces)
            {
                services.AddScoped(service, implementation);
            }
        }
    }
}
