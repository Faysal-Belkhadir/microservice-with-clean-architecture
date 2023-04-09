// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

#region usings

using MicroserviceWithCleanArchitecture.Persistence.Extensions;

using System.Reflection;

#endregion

namespace MicroserviceWithCleanArchitecture.Persistence;

/// <inheritdoc />
public class DatabaseContext : DbContext
{
    /// <inheritdoc />
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Employee> Employees { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigDomainModels();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
