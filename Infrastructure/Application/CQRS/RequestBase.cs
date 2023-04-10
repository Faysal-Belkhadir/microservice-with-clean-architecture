// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Infrastructure.Application.CQRS;

public abstract class RequestBase
{
    protected RequestBase()
    {
        TimeStamp = DateTime.UtcNow;
        MessageType = GetType().Name;
    }

    public DateTime TimeStamp { get; protected set; }
    public string MessageType { get; protected set; }
}
