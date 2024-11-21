using OnlineAccounting.Application.Authentication.Models;
using OnlineAccounting.Domain;

namespace OnlineAccounting.Application.Authentication;

public interface IAuthenticationService : IScopedDependency
{
    Task<LoginResponse> Login(LoginInput input);
}