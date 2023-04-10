// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Infrastructure.Application.CQRS;

public interface IBusMediator
{
    Task<object?> SendQuery<T>(T query)
        where T : class;

    Task<object?> SendCommand<T>(T command)
        where T : class;
}
