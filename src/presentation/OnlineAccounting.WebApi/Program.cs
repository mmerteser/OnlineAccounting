using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Application;
using OnlineAccounting.Domain.Entities.AppEntities.Identity;
using OnlineAccounting.Persistence;
using OnlineAccounting.Persistence.Context;
using OnlineAccounting.Persistence.DataSeeding;
using OnlineAccounting.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("DefaultConnection");

services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<CompanyDbContext>(provider =>
{
    var factory = provider.GetRequiredService<IDbContextFactory<CompanyDbContext>>();
    return factory.CreateDbContext();
});

services.AddIdentity<AppUser, AppRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedEmail = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

services.RegisterPersistenceServices();
services.RegisterApplicationServices();

var serviceProvider = services.BuildServiceProvider();

serviceProvider
    .CreateMigration()
    .AddAdminUser();

services.AddControllers();

services.AddEndpointsApiExplorer();

services.AddSwaggerGenOpt();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsePersistenceServices();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseHttpsRedirection();

app.Run();