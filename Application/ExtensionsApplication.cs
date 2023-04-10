// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

#region usings

using MicroserviceWithCleanArchitecture.Application.Company.Queries;

#endregion

namespace MicroserviceWithCleanArchitecture.Application;

public static class ExtensionsApplication
{
    public static void AddCqrsServices(this IServiceCollection serviceCollection)
    {
        AddCommandServices(serviceCollection);
        AddQueryServices(serviceCollection);
    }

    public static void AddRepositoryServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }

    #region Private

    private static void AddQueryServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IRequestHandler<QueryGetCompanyInfo, CompanyInfoDto>,
                QueryGetCompanyInfoHandler>();
    }

    private static void AddCommandServices(IServiceCollection serviceCollection)
    {
    }

    #endregion
}
