using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Domain.Entities.CompanyEntities;

namespace OnlineAccounting.Persistence.Context;

public sealed class CompanyDbContext(DbContextOptions<CompanyDbContext> options) : DbContext(options)
{
    public DbSet<GLAccount> GlAccounts { get; set; }
}