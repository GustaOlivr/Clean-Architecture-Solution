using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infra.Data.EF.Mapping.User
{
    /// <summary>
    /// Provides configuration for the <see cref="User"/> entity.
    /// Inherits from <see cref="BaseEntityConfiguration{User}"/> to reuse common configurations.
    /// </summary>
    public sealed class UserConfiguration : BaseEntityConfiguration<Domain.Entities.User>
    {
        /// <summary>
        /// Configures the <see cref="User"/> entity.
        /// Defines primary key, properties, and other constraints.
        /// </summary>
        /// <param name="builder">A <see cref="EntityTypeBuilder{User}"/> used to configure the <see cref="User"/> entity.</param>
        public override void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
        {
            // Defines the primary key for the User entity.
            builder.HasKey(x => x.Id);

            // Configures the Name property with a maximum length of 100 characters and marks it as required.
            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            // Configures the Email property with a maximum length of 50 characters and marks it as required.
            builder.Property(x => x.Email)
                   .HasMaxLength(50)
                   .IsRequired();

            // Calls the base configuration method to apply additional configurations.
            base.Configure(builder);
        }
    }
}
