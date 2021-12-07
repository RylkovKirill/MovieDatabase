using System;
using System.Collections.Generic;

namespace MovieDatabase.Core.Entities.Catalog
{
    public class Director : Entity<Guid>
    {
        public const int FirstNameLength = 64;
        public const int LastNameLength = 64;
        public const int CountryLength = 32;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Movie> Movies { get; set; }
    }
}
