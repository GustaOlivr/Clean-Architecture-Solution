using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    /// <summary>
    /// Base interface for CRUD operations on a domain entity.
    /// </summary>
    /// <typeparam name="T">The type of the entity that inherits from <see cref="BaseEntity"/>.</typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Creates a new entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be created.</param>
        void Create(T entity);

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        void Update(T entity);

        /// <summary>
        /// Removes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        void Delete(T entity);

        /// <summary>
        /// Gets an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns the found entity or <c>null</c> if not found.</returns>
        Task<T> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets all entities from the database.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns a list of all entities.</returns>
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}
