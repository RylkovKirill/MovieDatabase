using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.Catalog;

namespace MovieDatabase.Infrastructure.Configs.Catalog
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(g => g.Id).IsUnique();

            builder.Property(g => g.Name).IsRequired().HasMaxLength(Genre.NameLength);
            builder.Property(g => g.Description).HasMaxLength(Genre.DescriptionLength);

            builder.HasMany(g => g.Movies).WithMany(m => m.Genres);
        }
    }
}
