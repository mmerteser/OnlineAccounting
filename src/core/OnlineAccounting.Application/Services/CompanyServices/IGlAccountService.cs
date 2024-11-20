using OnlineAccounting.Application.DomainModels.CompanyDomains.GlAccountDomainModels;
using OnlineAccounting.Domain;
using OnlineAccounting.Domain.Entities.CompanyEntities;

namespace OnlineAccounting.Application.Services.CompanyServices;

public interface IGlAccountService : IScopedDependency
{
    Task<GLAccount> CreateGlAccountAsync(CreateGlAccountInput input);   
}