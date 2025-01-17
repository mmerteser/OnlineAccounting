namespace OnlineAccounting.Application.Authentication.Models;

public sealed class LoginResponse
{
    public string Token { get; set; }
    public string Email { get; set; }
    public string UserId { get; set; }
    public string FullName { get; set; }
}