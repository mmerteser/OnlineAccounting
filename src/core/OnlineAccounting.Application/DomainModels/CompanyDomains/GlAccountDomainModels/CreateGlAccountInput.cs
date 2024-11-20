namespace OnlineAccounting.Application.DomainModels.CompanyDomains.GlAccountDomainModels;

public class CreateGlAccountInput
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public char Type { get; set; }
}