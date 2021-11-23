using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Entities.History;
using MovieDatabase.Core.Entities.Membership;
using MovieDatabase.Infrastructure.Configs.Catalog;
using MovieDatabase.Infrastructure.Configs.Membership;
using System;

namespace MovieDatabase.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<MovieHistory> MoviesHistory { get; set; }
        public DbSet<ReviewHistory> ReviewsHistory { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new RoleConfig());
            builder.ApplyConfiguration(new ActorConfig());
            builder.ApplyConfiguration(new DirectorConfig());
            builder.ApplyConfiguration(new DistributorConfig());
            builder.ApplyConfiguration(new GenreConfig());
            builder.ApplyConfiguration(new MovieConfig());
            builder.ApplyConfiguration(new RatingConfig());
            builder.ApplyConfiguration(new ReviewConfig());

            builder.ApplyConfiguration(new MovieHistoryConfig());
            builder.ApplyConfiguration(new ReviewHistoryConfig());

            base.OnModelCreating(builder);
        }
    }
}
