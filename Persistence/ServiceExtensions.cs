using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
    /// <summary>
    /// Provides extension methods for configuring the persistence layer services.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures the persistence services for the application, including the database context and repositories.
        /// </summary>
        /// <param name="services">The service collection to which the services are added.</param>
        /// <param name="configuration">The configuration settings used to configure the services.</param>
        public static void ConfigurePersistenceApp(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            string connectionStringPostgre = configuration.GetConnectionString("Postgre");

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(connectionStringPostgre,
                    b => b.MigrationsAssembly("CleanArchitecture.Persistence")));

            // Register the UnitOfWork and UserRepository services with scoped lifetime.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
