using Microsoft.AspNetCore.Identity;

namespace OnlineAccounting.Domain.Entities.AppEntities.Identity;

public sealed class AppUser : IdentityUser
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}