using AutoMapper;
using OnlineAccounting.Application.DomainModels.CompanyDomains.GlAccountDomainModels;
using OnlineAccounting.Domain.Entities.CompanyEntities;

namespace OnlineAccounting.Application.MappingProfiles;

public sealed class GlAccountMappings : Profile
{
    public GlAccountMappings()
    {
        CreateMap<GLAccount, CreateGlAccountInput>().ReverseMap();
    }
}