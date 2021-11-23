using MovieDatabase.Core.Entities.Catalog;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Web.Areas.Admin.ViewModels
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(Movie.NameLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(Movie.CountryLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Language")]
        [StringLength(Movie.LanguageLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(Movie.DescriptionLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        [StringLength(Movie.ImagePathLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Budget")]
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [Required]
        [Display(Name = "BoxOffice")]
        [DataType(DataType.Currency)]
        public decimal BoxOffice { get; set; }

        [Required]
        [Display(Name = "Runtime")]
        [DataType(DataType.Duration)]
        public TimeSpan Runtime { get; set; }

        [Required]
        [Display(Name = "Date Of Release")]
        [DataType(DataType.Date)]
        public DateTime DateOfRelease { get; set; }

        public Guid? RatingId { get; set; }
        public Guid? DirectorId { get; set; }
        public Guid? DistributorId { get; set; }
    }
}
