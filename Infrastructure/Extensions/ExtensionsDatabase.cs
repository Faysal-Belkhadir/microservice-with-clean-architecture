// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

#region usings

using MicroserviceWithCleanArchitecture.Shared.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace MicroserviceWithCleanArchitecture.Infrastructure.Extensions;

public static class ExtensionsDatabase
{
    public static void AddDatabaseInfra<TDbContext>(
        this IServiceCollection serviceCollection,
        DatabaseProviderEnum databaseProvider,
        string connectionString,
        string migrationsAssemblyName
    )
        where TDbContext : DbContext
    {
        switch (databaseProvider)
        {
            case DatabaseProviderEnum.PostgreSQL:
                AddPostgreSqlDb<TDbContext>(serviceCollection, connectionString, migrationsAssemblyName);
                break;
            case DatabaseProviderEnum.MicrosoftSqlServer:
                AddMicrosoftSqlServerDb<TDbContext>(serviceCollection, connectionString, migrationsAssemblyName);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(databaseProvider), databaseProvider, null);
        }
    }

    private static void AddMicrosoftSqlServerDb<TDbContext>(
        IServiceCollection services,
        string connectionString,
        string migrationsAssemblyName
    )
        where TDbContext : DbContext
    {
        services.AddDbContextPool<TDbContext>(_ => _.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssemblyName)));
    }

    private static void AddPostgreSqlDb<TDbContext>(IServiceCollection services, string? connectionString, string migrationsAssemblyName)
        where TDbContext : DbContext
    {
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<TDbContext>(_ => _.UseNpgsql(connectionString, b => b.MigrationsAssembly(migrationsAssemblyName)));
    }
}
