using OnlineAccounting.Application;
using OnlineAccounting.Persistence;
using OnlineAccounting.WebApi.ActionFilters;
using OnlineAccounting.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("DefaultConnection");

services.AddHttpContextAccessor();

services.AddIdentityServer();
services.RegisterPersistenceServices(connectionString!);
services.RegisterApplicationServices();

services.AddAuthenticationConfiguration(configuration);

services.AddMiddlewares();

services.AddControllers(opt => opt.Filters.Add<ValidationActionFilter>());

services.AddEndpointsApiExplorer();

services.AddSwaggerGenOpt();

var app = builder.Build();

app.ConfigureDataSeeding();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UsePersistenceServices();
app.UseMiddlewares();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseHttpsRedirection();

app.Run();