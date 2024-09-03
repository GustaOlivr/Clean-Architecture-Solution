using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infra.Data.EF.Mapping.User
{
    public sealed class UserConfiguration : BaseEntityConfiguration<Domain.Entities.User>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();

            base.Configure(builder);
        }
    }
}
