using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OnlineAccounting.Domain;

namespace OnlineAccounting.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddServicesFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any())
            .ToList();

        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
                if (typeof(ITransientDependency).IsAssignableFrom(@interface))
                    services.AddTransient(@interface, type);
                else if (typeof(IScopedDependency).IsAssignableFrom(@interface))
                    services.AddScoped(@interface, type);
                else if (typeof(ISingletonDependency).IsAssignableFrom(@interface))
                    services.AddSingleton(@interface, type);
        }
    }
}