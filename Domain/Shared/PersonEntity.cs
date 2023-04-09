// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Domain.Shared;

/// <summary>
/// Person Entity
/// </summary>
/// <inheritdoc />
public abstract class PersonEntity : BaseEntity
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    public string Gender { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    public string? Phone { get; set; }
}
