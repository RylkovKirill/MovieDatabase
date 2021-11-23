using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.History;

namespace MovieDatabase.Infrastructure.Configs.Catalog
{
    public class ReviewHistoryConfig : IEntityTypeConfiguration<ReviewHistory>
    {
        public void Configure(EntityTypeBuilder<ReviewHistory> builder)
        {
            builder.HasIndex(r => r.Id).IsUnique();

            builder.Property(r => r.Rating).IsRequired();
            builder.Property(r => r.Content).HasMaxLength(ReviewHistory.ContentLength);
            builder.Property(r => r.Action).HasMaxLength(ReviewHistory.ActionLength);
            builder.Property(r => r.DateCreated).IsRequired();
            builder.Property(r => r.DateUpdated).IsRequired();

        }
    }
}
