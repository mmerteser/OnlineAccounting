using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineAccounting.Application;

public static class ServiceRegistration
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}