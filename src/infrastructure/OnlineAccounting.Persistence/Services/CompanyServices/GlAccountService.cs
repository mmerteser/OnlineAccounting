using AutoMapper;
using OnlineAccounting.Application.DomainModels.CompanyDomains.GlAccountDomainModels;
using OnlineAccounting.Application.Repositories;
using OnlineAccounting.Application.Services.CompanyServices;
using OnlineAccounting.Domain.Entities.CompanyEntities;
using OnlineAccounting.Persistence.Context;

namespace OnlineAccounting.Persistence.Services.CompanyServices;

public sealed class GlAccountService(IRepository<CompanyDbContext, GLAccount> glAccountRepository, IMapper mapper) : IGlAccountService
{
    public async Task<GLAccount> CreateGlAccountAsync(CreateGlAccountInput input)
    {
        var glAccount = mapper.Map<GLAccount>(input);
        
        var addedEntity = await glAccountRepository.Add(glAccount);
        await glAccountRepository.SaveChangesAsync();
        return addedEntity.Entity;
    }
}