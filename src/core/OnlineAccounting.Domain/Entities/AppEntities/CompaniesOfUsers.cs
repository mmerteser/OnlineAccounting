using System.ComponentModel.DataAnnotations.Schema;
using OnlineAccounting.Domain.Entities.AppEntities.Identity;

namespace OnlineAccounting.Domain.Entities.AppEntities;

public sealed class CompaniesOfUsers : Entity
{
    public string UserId { get; set; }

    [ForeignKey(nameof(UserId))] public AppUser AppUser { get; set; }

    public long CompanyId { get; set; }

    [ForeignKey(nameof(CompanyId))] public Company Company { get; set; }
}