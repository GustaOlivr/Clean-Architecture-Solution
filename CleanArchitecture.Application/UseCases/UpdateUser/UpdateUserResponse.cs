using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
    /// <summary>
    /// Represents the response returned after updated a existing user.
    /// </summary>
    public sealed record UpdateUserResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user to be updated.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user to be updated.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the user to be updated.
        /// </summary>
        public string? Name { get; set; }
    }
}
