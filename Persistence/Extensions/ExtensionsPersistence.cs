// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Persistence.Extensions;

public static class ExtensionsPersistence
{
    public static void ConfigDomainModels(this ModelBuilder modelBuilder)
    {
        ConfigRelationships(modelBuilder);
    }

    private static void ConfigRelationships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasMany(_ => _.Departments)
            .WithOne(_ => _.Company)
            ;

        modelBuilder.Entity<Department>()
            .HasMany(_ => _.Employees)
            .WithOne(_ => _.Department)
            ;
    }
}
