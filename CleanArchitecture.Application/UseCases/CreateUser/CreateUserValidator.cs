using FluentValidation;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    /// <summary>
    /// Defines validation rules for the <see cref="CreateUserRequest"/>.
    /// </summary>
    public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserValidator"/> class.
        /// Configures validation rules for email and name properties.
        /// </summary>
        public CreateUserValidator()
        {
            // Ensure that the email is not empty, has a maximum length of 50, and is a valid email address.
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress();

            // Ensure that the name is not empty, has a minimum length of 3, and a maximum length of 50.
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);
        }
    }
}