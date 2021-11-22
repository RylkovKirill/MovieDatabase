using MovieDatabase.Core.Entities.Membership;
using System;

namespace MovieDatabase.Core.Entities.Catalog
{
    public class Review : Entity<Guid>
    {
        public const int ContentLength = 2048;

        public int Rating { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
