// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

#region usings

using MicroserviceWithCleanArchitecture.Infrastructure.Application.CQRS;

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace MicroserviceWithCleanArchitecture.Infrastructure.Extensions;

public static class ExtensionsCqrs
{
    public static IServiceCollection AddCqrsInfra(
        this IServiceCollection serviceCollection,
        Type applicationIndicator
    )
    {
        serviceCollection.AddMediatR(applicationIndicator);
        serviceCollection.AddValidatorsFromAssembly(applicationIndicator.Assembly);
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        serviceCollection.AddTransient<IBusMediator, BusMediator>();

        return serviceCollection;
    }
}
