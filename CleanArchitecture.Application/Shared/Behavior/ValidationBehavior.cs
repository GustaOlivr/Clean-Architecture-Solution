using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shared.Behavior
{
    /// <summary>
    /// Pipeline behavior that validates incoming requests using FluentValidation.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request being handled.</typeparam>
    /// <typeparam name="TResponse">The type of the response returned by the handler.</typeparam>
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                                                                  where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="validators">The validators to be applied to the request.</param>
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Handles the request validation process and passes the request to the next handler in the pipeline if valid.
        /// </summary>
        /// <param name="request">The incoming request to be validated.</param>
        /// <param name="next">The next delegate in the pipeline to be invoked if the validation is successful.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation, containing the response from the next handler.</returns>
        /// <exception cref="FluentValidation.ValidationException">Thrown if any validation errors are found.</exception>
        public async Task<TResponse> Handle(TRequest request,
                                             RequestHandlerDelegate<TResponse> next,
                                             CancellationToken cancellationToken)
        {
            // If there are no validators, continue to the next handler.
            if (!_validators.Any()) return await next();

            // Create a validation context for the request.
            var context = new ValidationContext<TRequest>(request);

            // Execute all validators and collect any validation failures.
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            // If there are any validation failures, throw a validation exception.
            if (failures.Count != 0)
            {
                throw new FluentValidation.ValidationException(failures);
            }

            // Continue to the next handler in the pipeline.
            return await next();
        }
    }
}
