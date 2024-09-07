using FluentValidation;

namespace CleanArchitecture.Application.UseCases.DeleteUser
{
    /// <summary>
    /// Validator for the <see cref="DeleteUserRequest"/> to ensure the ID is provided and valid.
    /// </summary>
    public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserValidator"/> class.
        /// </summary>
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
