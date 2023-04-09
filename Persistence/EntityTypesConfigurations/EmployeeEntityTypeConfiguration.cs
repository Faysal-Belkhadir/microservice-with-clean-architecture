// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroserviceWithCleanArchitecture.Persistence.EntityTypesConfigurations;

/// <inheritdoc />
public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable(nameof(Employee));

        #region Rquired

        builder.Property(_ => _.Position).IsRequired();
        builder.Property(_ => _.HiredOn).IsRequired();

        #endregion
    }
}
