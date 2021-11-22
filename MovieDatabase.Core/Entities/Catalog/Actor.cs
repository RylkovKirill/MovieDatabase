using System;
using System.Collections.Generic;

namespace MovieDatabase.Core.Entities.Catalog
{
    public class Actor : Entity<Guid>
    {
        public const int FirstNameLength = 64;
        public const int LastNameLength = 64;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Movie> Movies { get; set; }
    }
}
