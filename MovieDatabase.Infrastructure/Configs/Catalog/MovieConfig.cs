using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.Catalog;

namespace MovieDatabase.Infrastructure.Configs.Catalog
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasIndex(m => m.Id).IsUnique();

            builder.Property(m => m.Name).IsRequired().HasMaxLength(Movie.NameLength);
            builder.Property(m => m.Country).IsRequired().HasMaxLength(Movie.CountryLength);
            builder.Property(m => m.Language).IsRequired().HasMaxLength(Movie.LanguageLength);
            builder.Property(m => m.ImagePath).HasMaxLength(Movie.ImagePathLength);
            builder.Property(m => m.Description).HasMaxLength(Movie.DescriptionLength);
            builder.Property(m => m.Budget).IsRequired().HasPrecision(14, 2);
            builder.Property(m => m.BoxOffice).IsRequired().HasPrecision(14, 2);

            builder.HasOne(m => m.Rating).WithMany(r => r.Movies).HasForeignKey(m => m.RatingId);
            builder.HasOne(m => m.Director).WithMany(d => d.Movies).HasForeignKey(m => m.DirectorId);
            builder.HasOne(m => m.Distributor).WithMany(d => d.Movies).HasForeignKey(m => m.DistributorId);

            builder.HasMany(m => m.Reviews).WithOne(r => r.Movie).HasForeignKey(r => r.MovieId);

            builder.HasMany(m => m.Actors).WithMany(a => a.Movies);
            builder.HasMany(m => m.Genres).WithMany(g => g.Movies);
        }
    }
}
