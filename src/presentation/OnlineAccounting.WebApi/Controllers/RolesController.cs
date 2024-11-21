using Microsoft.AspNetCore.Mvc;
using OnlineAccounting.Application.Services.AppServices;

namespace OnlineAccounting.WebApi.Controllers;

public sealed class RolesController(IRoleService roleService) : BaseApiController
{
    [HttpPost("[action]")]
    public async Task Create(string role)
    {
        await roleService.AddRoleAsync(role);
    }

    [HttpPost("[action]")]
    public async Task AddRoleToUser(string userId, List<string> roles)
    {
        await roleService.AddRolesToUserAsync(userId, roles);
    }
}