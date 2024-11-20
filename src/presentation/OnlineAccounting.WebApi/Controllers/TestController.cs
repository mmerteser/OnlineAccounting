using Microsoft.AspNetCore.Mvc;
using OnlineAccounting.Application.DomainModels.AppDomains.CompanyDomainModels;
using OnlineAccounting.Application.Services.AppServices;
using OnlineAccounting.Domain.Entities.AppEntities;

namespace OnlineAccounting.WebApi.Controllers;

public sealed class TestController(ICompanyService companyService) : BaseApiController
{
    [HttpPost("[action]")]
    public async Task<Company> Post([FromBody] CreateCompanyInput input)
    {
        return await companyService.CreateCompany(input);
    }
}