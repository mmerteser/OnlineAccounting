namespace OnlineAccounting.Application.DomainModels.AppDomains.CompanyDomainModels;

public class CreateCompanyInput
{
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string? Address { get; set; }
    public string? IdentityNumber { get; set; }
    public string? TaxDepartment { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string Server { get; set; } = null!;
    public int? Port { get; set; }
    public string SqlUser { get; set; } = null!;
    public string SqlPassword { get; set; } = null!;
    public string UserId { get; set; } = null!;
}