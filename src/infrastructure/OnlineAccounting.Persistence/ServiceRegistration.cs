using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OnlineAccounting.Application.Extensions;
using OnlineAccounting.Application.Repositories;
using OnlineAccounting.Application.Repositories.CompanyRepositories;
using OnlineAccounting.Persistence.Middlewares;
using OnlineAccounting.Persistence.Repositories;
using OnlineAccounting.Persistence.Repositories.CompanyRepositories;

namespace OnlineAccounting.Persistence;

public static class ServiceRegistration
{
    public static void RegisterPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        services.AddServicesFromAssembly(Assembly.GetExecutingAssembly());
    }

    public static void UsePersistenceServices(this IApplicationBuilder app)
    {
        app.UseMiddleware(typeof(TenantMiddleware));
    }
}