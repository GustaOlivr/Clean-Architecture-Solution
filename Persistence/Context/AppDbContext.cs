using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infra.Data.EF.Mapping.User;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Context
{
    /// <summary>
    /// Represents the application's database context, providing access to the database entities.
    /// Inherits from <see cref="DbContext"/>.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class with specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for the <see cref="User"/> entity.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Configures the Entity Framework model when creating the entities in the database.
        /// This method is called when the context is used for the first time.
        /// </summary>
        /// <param name="builder">A <see cref="ModelBuilder"/> used to build the model for the entities.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            //Add other configurations
        }
    }
}