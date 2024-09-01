using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    /// <summary>
    /// Provides a base implementation of the repository pattern for entities that inherit from <see cref="BaseEntity"/>.
    /// Implements common CRUD operations and interacts with the database using Entity Framework Core.
    /// </summary>
    /// <typeparam name="T">The type of the entity being managed. Must inherit from <see cref="BaseEntity"/>.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The database context used to interact with the database.
        /// </summary>
        protected readonly AppDbContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context to be used for database operations.</param>
        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Creates a new entity in the database.
        /// Sets the <see cref="BaseEntity.DateCreated"/> property to the current UTC date and time.
        /// </summary>
        /// <param name="entity">The entity to be created.</param>
        public void Create(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Add(entity);
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// Sets the <see cref="BaseEntity.DateUpdated"/> property to the current UTC date and time.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }

        /// <summary>
        /// Marks an entity as deleted in the database.
        /// Sets the <see cref="BaseEntity.DateDeleted"/> property to the current UTC date and time.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        public void Delete(T entity)
        {
            entity.DateDeleted = DateTimeOffset.UtcNow;
            Context.Remove(entity);
        }

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns the entity if found; otherwise, <c>null</c>.</returns>
        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <summary>
        /// Retrieves all entities from the database.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns a list of all entities.</returns>
        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
