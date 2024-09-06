using CleanArchitecture.Application.UseCases.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
    /// <summary>
    /// Defines validation rules for the <see cref="UpdateUserRequest"/>.
    /// </summary>
    public sealed class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserValidator"/> class.
        /// Configures validation rules for email and name properties.
        /// </summary>
        public UpdateUserValidator()
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
