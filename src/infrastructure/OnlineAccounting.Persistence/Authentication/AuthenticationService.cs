using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Application.Authentication;
using OnlineAccounting.Application.Authentication.Models;
using OnlineAccounting.Domain.Entities.AppEntities.Identity;

namespace OnlineAccounting.Persistence.Authentication;

public sealed class AuthenticationService(
    IJwtProvider jwtProvider,
    UserManager<AppUser> userManager) : IAuthenticationService
{
    public async Task<LoginResponse> Login(LoginInput input)
    {
        var user = await userManager.Users
            .Where(i => i.Email == input.EmailOrUsername || i.UserName == input.EmailOrUsername).FirstOrDefaultAsync();

        if (user is null) throw new Exception("User not found");

        bool checkUser = await userManager.CheckPasswordAsync(user, input.Password);

        if (!checkUser) throw new Exception("Invalid credentials");

        string token = await jwtProvider.GenerateToken(user,null);

        return new()
        {
            Email = user.Email,
            UserId = user.Id,
            FullName = user.FullName,
            Token = token
        };
    }
}