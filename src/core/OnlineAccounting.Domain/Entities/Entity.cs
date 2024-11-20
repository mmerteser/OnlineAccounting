namespace OnlineAccounting.Domain.Entities;

public abstract class Entity
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}