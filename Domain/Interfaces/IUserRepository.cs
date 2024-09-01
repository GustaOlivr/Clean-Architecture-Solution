using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Domain.Interfaces
{
    /// <summary>
    /// Represents the repository interface for managing user entity.
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Retrieves a user entity by its email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns the user entity if found; otherwise, <c>null</c>.</returns>
        Task<User> GetByEmail(string email, CancellationToken cancellationToken);
    }
}