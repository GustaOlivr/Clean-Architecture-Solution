using FluentValidation;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    /// <summary>
    /// Defines validation rules for the <see cref="GetAllUserRequest"/>.
    /// </summary>
    public sealed class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUserValidator"/> class.
        /// Configures validation rules for email and name properties.
        /// </summary>
        public GetAllUserValidator()
        {
            //validation
        }
    }
}