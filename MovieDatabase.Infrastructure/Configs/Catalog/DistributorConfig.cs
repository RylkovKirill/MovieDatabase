using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.Catalog;

namespace MovieDatabase.Infrastructure.Configs.Catalog
{
    public class DistributorConfig : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.HasIndex(d => d.Id).IsUnique();

            builder.Property(d => d.Name).IsRequired().HasMaxLength(Distributor.NameLength);
            builder.Property(d => d.Description).HasMaxLength(Distributor.DescriptionLength);

            builder.HasMany(d => d.Movies).WithOne(m => m.Distributor).HasForeignKey(m => m.DistributorId);
        }
    }
}
