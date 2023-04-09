// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroserviceWithCleanArchitecture.Persistence.EntityTypesConfigurations;

/// <inheritdoc />
public class CompanyEntityTypeConfiguration : IEntityTypeConfiguration<Company>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable(nameof(Company));

        #region Rquired

        builder.Property(_ => _.Address).IsRequired();
        builder.Property(_ => _.Country).IsRequired();

        #endregion
    }
}
