using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Application.DomainModels.AppDomains.CompanyDomainModels;
using OnlineAccounting.Application.Repositories;
using OnlineAccounting.Application.Services.AppServices;
using OnlineAccounting.Application.Services.Tenant;
using OnlineAccounting.Domain.Entities.AppEntities;
using OnlineAccounting.Persistence.Context;

namespace OnlineAccounting.Persistence.Services.AppServices;

public sealed class CompanyService(
    IUnitOfWork<AppDbContext> unitOfWork,
    IRepository<AppDbContext, Company> companyRepository,
    IRepository<AppDbContext, CompaniesOfUsers> companiesOfUsersRepository,
    IMapper mapper,
    ITenantService tenantService)
    : ICompanyService
{
    public async Task<Company> CreateCompany(CreateCompanyInput input)
    {
        try
        {
            var company = mapper.Map<Company>(input);

            await unitOfWork.BeginTransactionAsync();

            var added = await companyRepository.Add(company);
            await unitOfWork.CompleteAsync();

            await companiesOfUsersRepository.Add(new CompaniesOfUsers
            {
                CompanyId = added.Entity.Id,
                UserId = input.UserId
            });

            await unitOfWork.CompleteAsync();

            await MigrateCompanyDatabase(company);

            await unitOfWork.CommitTransactionAsync();

            return added.Entity;
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task MigrateCompanyDatabase(Company input)
    {
        var connectionString = tenantService.GetTenantConnectionString(input);
        var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        await using var context = new CompanyDbContext(optionsBuilder.Options);
        if (await context.Database.CanConnectAsync())
        {
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
                await context.Database.MigrateAsync();
        }
        else
        {
            await context.Database.MigrateAsync();
        }
    }
}