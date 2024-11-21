using Microsoft.AspNetCore.Identity;
using OnlineAccounting.Application.Services.AppServices;
using OnlineAccounting.Domain.Entities.AppEntities.Identity;

namespace OnlineAccounting.Persistence.Services.AppServices;

public sealed class RoleService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : IRoleService
{
    public async Task AddRolesToUserAsync(string userId, List<string> roles)
    {
        var user = await userManager.FindByIdAsync(userId);
        var addRoleResult = await userManager.AddToRolesAsync(user, roles);
    }

    public async Task AddRoleAsync(string role)
    {
        var result = await roleManager.CreateAsync(new AppRole() { Name = role });
    }
}