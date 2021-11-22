using System;
using System.Collections.Generic;

namespace MovieDatabase.Core.Entities.Catalog
{
    public class Genre : Entity<Guid>
    {
        public const int NameLength = 64;
        public const int DescriptionLength = 2048;

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
