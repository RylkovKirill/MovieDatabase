﻿using MovieDatabase.Core.Entities.Catalog;
using System;

namespace MovieDatabase.Core.Entities.History
{
    public class MovieHistory : Entity<Guid>
    {
        public const int NameLength = 64;
        public const int CountryLength = 32;
        public const int LanguageLength = 32;
        public const int ImagePathLength = 64;
        public const int DescriptionLength = 2048;
        public const int ActionLength = 64;

        public Guid MovieId { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Action { get; set; }
        public decimal Budget { get; set; }
        public decimal BoxOffice { get; set; }
        public TimeSpan Runtime { get; set; }
        public DateTime DateOfRelease { get; set; }
        public DateTime Date { get; set; }

        public Guid? RatingId { get; set; }
        public Guid? DirectorId { get; set; }
        public Guid? DistributorId { get; set; }

        public Rating Rating { get; set; }
        public Director Director { get; set; }
        public Distributor Distributor { get; set; }
    }
}
