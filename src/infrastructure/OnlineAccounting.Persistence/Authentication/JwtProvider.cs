using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineAccounting.Application.Authentication;
using OnlineAccounting.Domain.Authentication;
using OnlineAccounting.Domain.Entities.AppEntities.Identity;

namespace OnlineAccounting.Persistence.Authentication;

public sealed class JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager) : IJwtProvider
{
    public async Task<string> GenerateToken(AppUser user, List<string> roles)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Authentication, user.Id),
            new(ClaimTypes.Role, roles is null ? String.Empty : String.Join(",", roles)),
        };

        DateTime expires = DateTime.UtcNow.AddDays(1);
        JwtSecurityToken securityToken = new(issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256));

        string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = expires.AddDays(1);
        await userManager.UpdateAsync(user);
        return tokenString;
    }
}