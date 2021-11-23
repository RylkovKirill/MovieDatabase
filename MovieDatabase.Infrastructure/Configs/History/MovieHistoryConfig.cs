using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.History;

namespace MovieDatabase.Infrastructure.Configs.Catalog
{
    public class MovieHistoryConfig : IEntityTypeConfiguration<MovieHistory>
    {
        public void Configure(EntityTypeBuilder<MovieHistory> builder)
        {
            builder.HasIndex(m => m.Id).IsUnique();

            builder.Property(m => m.Name).IsRequired().HasMaxLength(MovieHistory.NameLength);
            builder.Property(m => m.Country).IsRequired().HasMaxLength(MovieHistory.CountryLength);
            builder.Property(m => m.Language).IsRequired().HasMaxLength(MovieHistory.LanguageLength);
            builder.Property(m => m.Language).IsRequired().HasMaxLength(MovieHistory.LanguageLength);
            builder.Property(m => m.ImagePath).HasMaxLength(MovieHistory.ImagePathLength);
            builder.Property(m => m.Description).HasMaxLength(MovieHistory.DescriptionLength);
            builder.Property(m => m.Action).HasMaxLength(MovieHistory.ActionLength);
            builder.Property(m => m.Budget).IsRequired().HasPrecision(14, 2);
            builder.Property(m => m.BoxOffice).IsRequired().HasPrecision(14, 2);
        }
    }
}
