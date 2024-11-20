using OnlineAccounting.Domain;
using OnlineAccounting.Domain.Entities.AppEntities;

namespace OnlineAccounting.Application.Services.Tenant;

public interface ITenantService : IScopedDependency
{
    Task<Company> GetTenantByIdAsync(long companyId);
    string GetTenantConnectionString(Company company);
}