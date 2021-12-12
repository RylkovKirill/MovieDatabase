using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.Catalog;

namespace MovieDatabase.Infrastructure.Configs.Catalog
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasIndex(a => a.Id).IsUnique();

            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(Actor.FirstNameLength);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(Actor.LastNameLength);
            builder.Property(a => a.Country).IsRequired().HasMaxLength(Actor.CountryLength);
            builder.Property(a => a.Biography).HasMaxLength(Actor.BiographyLength);
            builder.Property(a => a.DateOfBirth).IsRequired();

            builder.HasMany(a => a.Movies).WithMany(m => m.Actors);
        }
    }
}
