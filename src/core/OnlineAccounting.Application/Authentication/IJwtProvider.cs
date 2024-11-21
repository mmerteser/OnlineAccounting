using OnlineAccounting.Domain;
using OnlineAccounting.Domain.Entities.AppEntities.Identity;

namespace OnlineAccounting.Application.Authentication;

public interface IJwtProvider : IScopedDependency
{
    Task<string> GenerateToken(AppUser user, List<string> roles);
}