using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application.Services
{
    /// <summary>
    /// Provides extension methods for configuring application-level services.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures application services including AutoMapper, MediatR, and FluentValidation.
        /// </summary>
        /// <param name="services">The service collection to add the services to.</param>
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            // Registers AutoMapper with the assemblies of the current executing application.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Registers MediatR with the assemblies of the current executing application.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Registers all FluentValidation validators from the assemblies of the current executing application.
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
