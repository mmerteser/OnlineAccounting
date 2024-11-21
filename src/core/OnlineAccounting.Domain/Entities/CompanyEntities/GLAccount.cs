using System.ComponentModel.DataAnnotations;

namespace OnlineAccounting.Domain.Entities.CompanyEntities;

public sealed class GLAccount : Entity
{
    [Required] [StringLength(50)] public string Code { get; set; }

    [Required] [StringLength(400)] public string Name { get; set; }

    [Required] public char Type { get; set; }
}