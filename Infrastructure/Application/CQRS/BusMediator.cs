// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Infrastructure.Application.CQRS;

/// <inheritdoc />
public class BusMediator : IBusMediator
{
    private readonly IMediator _Mediator;

    public BusMediator(IMediator mediator)
    {
        _Mediator = mediator;
    }

    /// <inheritdoc />
    public Task<object?> SendCommand<T>(T command)
        where T : class
    {
        return _Mediator.Send(command);
    }

    /// <inheritdoc />
    public Task<object?> SendQuery<T>(T query)
        where T : class
    {
        return _Mediator.Send(query);
    }
}
