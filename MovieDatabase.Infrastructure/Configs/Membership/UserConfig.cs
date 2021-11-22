using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Core.Entities.Membership;

namespace MovieDatabase.Infrastructure.Configs.Membership
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Reviews).WithOne(r => r.User).HasForeignKey(r => r.UserId);
        }
    }
}
