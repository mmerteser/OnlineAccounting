using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineAccounting.Application.Services.Tenant;
using OnlineAccounting.Domain.Entities.AppEntities;

namespace OnlineAccounting.Persistence.Context;

public class CompanyDbContextFactory(IHttpContextAccessor httpContextAccessor, ITenantService tenantService)
    : IDbContextFactory<CompanyDbContext>
{
    public CompanyDbContext CreateDbContext()
    {
        var tenant = httpContextAccessor.HttpContext?.Items["Tenant"];

        var company = tenant as Company;

        if (tenant == null)
            throw new InvalidOperationException("Company information is not available.");

        var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();
        optionsBuilder.UseSqlServer(tenantService.GetTenantConnectionString(company));

        return new CompanyDbContext(optionsBuilder.Options);
    }
}

public class DesignTimeCompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
{
    public CompanyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();
        var connectionString =
            "Server=localhost;Database=AccountingCompanyDb;User=sa;Password=123;Trusted_Connection=true;TrustServerCertificate=true;";

        optionsBuilder.UseSqlServer(connectionString);

        return new CompanyDbContext(optionsBuilder.Options);
    }
}