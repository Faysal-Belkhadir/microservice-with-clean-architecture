// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

#region usings

using System.Reflection;

using MicroserviceWithCleanArchitecture.Infrastructure.Extensions;
using MicroserviceWithCleanArchitecture.Persistence;
using MicroserviceWithCleanArchitecture.Shared.Enums;

#endregion

namespace MicroserviceWithCleanArchitecture.API.Extensions;

public static class ExtensionsApi
{
    public static void AddDatabase(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        var migrationsAssemblyName = Assembly.GetExecutingAssembly().FullName;
        if (migrationsAssemblyName == null)
        {
            return;
        }

        var databaseProvider = configurationManager.GetSection("DatabaseProvider")["Type"];
        switch (databaseProvider)
        {
            case nameof(DatabaseProviderEnum.PostgreSQL):
                serviceCollection.AddDatabaseInfra<DatabaseContext>(
                    DatabaseProviderEnum.PostgreSQL,
                    configurationManager.GetConnectionString("PostgreSqlConnection")
                    ?? throw new ArgumentException("ConnectionString is null (PostgreSqlConnection)."),
                    migrationsAssemblyName
                );
                break;
            case nameof(DatabaseProviderEnum.MicrosoftSqlServer):
                serviceCollection.AddDatabaseInfra<DatabaseContext>(
                    DatabaseProviderEnum.MicrosoftSqlServer,
                    configurationManager.GetConnectionString("MicrosoftSqlServerConnection")
                    ?? throw new ArgumentException("ConnectionString is null (MicrosoftSqlServerConnection)."),
                    migrationsAssemblyName
                );
                break;
            default:
                throw new ArgumentException("No database provider fits for database setting.");
        }
    }
}
