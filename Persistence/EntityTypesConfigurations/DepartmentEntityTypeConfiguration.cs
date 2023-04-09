// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroserviceWithCleanArchitecture.Persistence.EntityTypesConfigurations;

/// <inheritdoc />
public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(nameof(Department));
    }
}
