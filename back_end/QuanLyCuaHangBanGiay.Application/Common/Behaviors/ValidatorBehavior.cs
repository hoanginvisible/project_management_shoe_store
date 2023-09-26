using FluentValidation;
using MediatR;
using Service.Common.Exceptions;

namespace Service.Common.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<IRequest>> _validators;

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var validationFailures = _validators
                .Select(validator => validator.Validate((IRequest)request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null)
                .ToList();

            if (validationFailures.Any())
            {
                var error = string.Join("\r\n", validationFailures);
                throw new DomainException(
                    $"Command validation Error for type {typeof(TRequest).Name}",
                    new ValidationException("Validation exception", validationFailures)
                );
            }

            return next();
        }
    }
}