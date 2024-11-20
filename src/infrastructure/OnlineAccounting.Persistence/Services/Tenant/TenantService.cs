using OnlineAccounting.Application.Services.Tenant;
using OnlineAccounting.Domain.Entities.AppEntities;
using OnlineAccounting.Persistence.Context;

namespace OnlineAccounting.Persistence.Services.Tenant;

public sealed class TenantService(AppDbContext context) : ITenantService
{
    public async Task<Company?> GetTenantByIdAsync(long companyId)
    {
        return await context.Companies.FindAsync(companyId);
    }

    public string GetTenantConnectionString(Company company)
    {
        return
            $"Server={company.Server},{company.Port};Database={company.ShortName}AccDb;User={company.SqlUser};Password={company.SqlPassword};TrustServerCertificate=true;";
    }
}