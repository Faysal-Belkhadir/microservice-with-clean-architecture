// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Domain;

/// <inheritdoc />
public class Company : ObjectEntity
{
    public string Address { get; set; } = null!;
    public string Country { get; set; } = null!;

    #region Relationships

    public ICollection<Department> Departments { get; set; } = new HashSet<Department>();

    #endregion
}
