// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Domain.Shared;

/// <summary>
/// Object Entity
/// </summary>
/// <inheritdoc />
public abstract class ObjectEntity : BaseEntity
{
    [Required]
    public string Name { get; set; } = null!;

    public string? Designation { get; set; }
}
