using Microsoft.AspNetCore.Mvc;
using OnlineAccounting.Application.DomainModels.AppDomains.CompanyDomainModels;
using OnlineAccounting.Application.DomainModels.CompanyDomains.GlAccountDomainModels;
using OnlineAccounting.Application.Services.AppServices;
using OnlineAccounting.Application.Services.CompanyServices;
using OnlineAccounting.Domain.Entities.AppEntities;
using OnlineAccounting.Domain.Entities.CompanyEntities;

namespace OnlineAccounting.WebApi.Controllers;

public sealed class TestController(IGlAccountService glAccountService) : BaseApiController
{
    [HttpPost("[action]")]
    public async Task<GLAccount> Post([FromBody] CreateGlAccountInput input)
    {
        return await glAccountService.CreateGlAccountAsync(input);
    }
}