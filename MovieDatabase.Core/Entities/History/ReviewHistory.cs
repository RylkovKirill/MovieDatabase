using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Entities.Membership;
using System;

namespace MovieDatabase.Core.Entities.History
{
    public class ReviewHistory : Entity<Guid>
    {
        public const int ContentLength = 2048;
        public const int ActionLength = 64;

        public Guid ReviewId { get; set; }

        public int Rating { get; set; }
        public string Content { get; set; }
        public string Action { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
