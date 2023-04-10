// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Infrastructure.Application.CQRS;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _Validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _Validators = validators;
    }

    /// <inheritdoc />
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _Validators
            .Select(_ => _.Validate(context))
            .SelectMany(_ => _.Errors)
            .Where(_ => _ != null)
            .ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        return next();
    }
}
