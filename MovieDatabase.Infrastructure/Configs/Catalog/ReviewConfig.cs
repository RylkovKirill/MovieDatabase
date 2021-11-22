using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.Catalog;

namespace MovieDatabase.Infrastructure.Configs.Catalog
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasIndex(r => r.Id).IsUnique();

            builder.Property(r => r.Rating).IsRequired();
            builder.Property(r => r.Content).HasMaxLength(Review.ContentLength);
            builder.Property(r => r.DateCreated).IsRequired();
            builder.Property(r => r.DateUpdated).IsRequired();

            builder.HasOne(r => r.Movie).WithMany(m => m.Reviews).HasForeignKey(r => r.MovieId);
        }
    }
}
