using OnlineAccounting.Application.DomainModels.AppDomains.CompanyDomainModels;
using OnlineAccounting.Domain;
using OnlineAccounting.Domain.Entities.AppEntities;

namespace OnlineAccounting.Application.Services.AppServices;

public interface ICompanyService : IScopedDependency
{
    Task<Company> CreateCompany(CreateCompanyInput input);
    Task MigrateCompanyDatabase(Company input);
}