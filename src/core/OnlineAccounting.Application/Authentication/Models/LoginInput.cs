namespace OnlineAccounting.Application.Authentication.Models;

public sealed class LoginInput
{
    public string EmailOrUsername { get; set; } = null!;
    public string Password { get; set; } = null!;
}