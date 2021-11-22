using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.Catalog;

namespace MovieDatabase.Infrastructure.Configs.Catalog
{
    public class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasIndex(r => r.Id).IsUnique();

            builder.Property(r => r.Name).IsRequired().HasMaxLength(Rating.NameLength);
            builder.Property(r => r.Description).HasMaxLength(Rating.DescriptionLength);

            builder.HasMany(r => r.Movies).WithOne(m => m.Rating).HasForeignKey(m => m.RatingId);
        }
    }
}
