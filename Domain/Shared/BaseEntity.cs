// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Domain.Shared;

/// <summary>
/// Base Entity
/// </summary>
public abstract class BaseEntity
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public DateTime Created { get; set; } = DateTime.UtcNow;

    [Required]
    public string CreatedBy { get; set; } = null!;

    [Required]
    public DateTime Modified { get; set; } = DateTime.UtcNow;

    [Required]
    public string ModifiedBy { get; set; } = null!;
}
