using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Domain.Entities.AppEntities;
using OnlineAccounting.Domain.Entities.AppEntities.Identity;

namespace OnlineAccounting.Persistence.Context;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<AppUser, AppRole, string>(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompaniesOfUsers> CompaniesOfUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>()
            .HasQueryFilter(i => !i.IsDeleted);

        builder.Entity<AppRole>()
            .HasQueryFilter(i => !i.IsDeleted);
    }
}