using OnlineAccounting.Persistence.DataSeeding;

namespace OnlineAccounting.WebApi.Extensions;

public static class DataSeedingConfigurator
{
    public static void ConfigureDataSeeding(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var scopedServiceProvider = scope.ServiceProvider;

        scopedServiceProvider
            .CreateMigration()
            .AddAdminUser();
    }
}