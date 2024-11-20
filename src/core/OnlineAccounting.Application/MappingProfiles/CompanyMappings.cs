using AutoMapper;
using OnlineAccounting.Application.DomainModels.AppDomains.CompanyDomainModels;
using OnlineAccounting.Domain.Entities.AppEntities;

namespace OnlineAccounting.Application.MappingProfiles;

public class CompanyMappings : Profile
{
    public CompanyMappings()
    {
        CreateMap<Company, CreateCompanyInput>().ReverseMap();
    }
}