using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.Catalog;

namespace MovieDatabase.Infrastructure.Configs.Catalog
{
    public class DirectorConfig : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasIndex(d => d.Id).IsUnique();

            builder.Property(d => d.FirstName).IsRequired().HasMaxLength(Director.FirstNameLength);
            builder.Property(d => d.LastName).IsRequired().HasMaxLength(Director.LastNameLength);
            builder.Property(d => d.DateOfBirth).IsRequired();

            builder.HasMany(d => d.Movies).WithOne(m => m.Director).HasForeignKey(m => m.DirectorId);
        }
    }
}
