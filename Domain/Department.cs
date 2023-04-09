// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Domain;

/// <inheritdoc />
public class Department : ObjectEntity
{
    public Company Company { get; set; } = new();

    #region Relationships

    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    #endregion
}
