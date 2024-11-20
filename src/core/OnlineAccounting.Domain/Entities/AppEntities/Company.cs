using System.ComponentModel.DataAnnotations;

namespace OnlineAccounting.Domain.Entities.AppEntities;

public sealed class Company : Entity
{
    [Required] [StringLength(400)] public string Name { get; set; } = null!;

    [Required] [StringLength(20)] public string ShortName { get; set; } = null!;

    [StringLength(2000)] public string? Address { get; set; }

    [StringLength(11)] public string? IdentityNumber { get; set; }

    [StringLength(200)] public string? TaxDepartment { get; set; }

    [StringLength(20)] public string? PhoneNumber { get; set; }

    [StringLength(100)] public string? Email { get; set; }

    [Required] [StringLength(100)] public string Server { get; set; } = null!;

    [Required] public int? Port { get; set; }

    [Required] [StringLength(20)] public string SqlUser { get; set; } = null!;

    [Required] [StringLength(36)] public string SqlPassword { get; set; } = null!;
}