using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.EF.Mapping
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            
        }
    }
}
