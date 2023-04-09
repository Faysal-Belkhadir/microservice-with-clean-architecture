// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.API.Controllers;

/// <summary>
/// Api base controller
/// </summary>
/// <typeparam name="T"></typeparam>
/// /// <inheritdoc />
public abstract class ApiBaseController<T> : ControllerBase
{
    protected readonly ILogger<T> Logger;
    protected readonly IWebHostEnvironment WebHostEnvironment;

    protected ApiBaseController(
        ILogger<T> logger,
        IWebHostEnvironment webHostEnvironment
    )
    {
        Logger = logger;
        WebHostEnvironment = webHostEnvironment;
    }

    protected ObjectResult ReturnStatusResult(
        LogLevel logLevel,
        int statusCode,
        string? logMessage = null,
        [ActionResultObjectValue] object? result = null
    )
    {
        if (!string.IsNullOrWhiteSpace(logMessage))
        {
            Logger.Log(logLevel, logMessage);
        }

        return StatusCode(statusCode, result);
    }
}
