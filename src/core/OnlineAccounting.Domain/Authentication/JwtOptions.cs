namespace OnlineAccounting.Domain.Authentication;

public sealed class JwtOptions
{
    public const string DefaultAuthenticationScheme = "Bearer";
    public const string OptinsSectionName = "Jwt";
    
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
}