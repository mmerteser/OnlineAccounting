using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineAccounting.Application.Extensions;
using OnlineAccounting.Application.Repositories;
using OnlineAccounting.Application.Services.Tenant;
using OnlineAccounting.Persistence.Context;
using OnlineAccounting.Persistence.Middlewares;
using OnlineAccounting.Persistence.Repositories;

namespace OnlineAccounting.Persistence;

public static class ServiceRegistration
{
    public static void RegisterPersistenceServices(this IServiceCollection services, string connectionString)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        services.AddServicesFromAssembly(Assembly.GetExecutingAssembly());
     
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        
        services.AddScoped<CompanyDbContext>(provider =>
        {
            var factory = provider.GetRequiredService<IDbContextFactory<CompanyDbContext>>();
            return factory.CreateDbContext();
        });

        services.AddScoped<IDbContextFactory<CompanyDbContext>>(provider =>
        {
            var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
            var tenantService = provider.GetRequiredService<ITenantService>();

            return new CompanyDbContextFactory(httpContextAccessor, tenantService);
        });
    }

    public static void UsePersistenceServices(this IApplicationBuilder app)
    {
        app.UseMiddleware(typeof(TenantMiddleware));
    }
}