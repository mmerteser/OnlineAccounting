using OnlineAccounting.Domain;

namespace OnlineAccounting.Application.Services.AppServices;

public interface IRoleService : IScopedDependency
{
    Task AddRolesToUserAsync(string userId, List<string> roles);
    Task AddRoleAsync(string role);
}