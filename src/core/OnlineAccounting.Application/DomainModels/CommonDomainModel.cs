namespace OnlineAccounting.Application.DomainModels;

public class CommonDomainModel
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
}