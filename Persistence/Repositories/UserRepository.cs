using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Persistence.Repositories
{
    /// <summary>
    /// Provides the repository implementation for managing <see cref="User"/> entities.
    /// Inherits from <see cref="BaseRepository{T}"/> and implements <see cref="IUserRepository"/>.
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context to be used for database operations.</param>
        public UserRepository(AppDbContext context) : base(context)
        { }

        /// <summary>
        /// Retrieves a user entity by its email address.
        /// </summary>
        /// <param name="email">The email address of the user to be retrieved.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns the user entity if found; otherwise, <c>null</c>.</returns>
        public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}