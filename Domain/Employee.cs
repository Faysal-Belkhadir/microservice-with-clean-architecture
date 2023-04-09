// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Domain;

/// <inheritdoc />
public class Employee : PersonEntity
{
    public string Position { get; set; } = null!;
    public DateOnly HiredOn { get; set; }

    #region Relationships

    public Department Department { get; set; } = null!;

    #endregion
}
