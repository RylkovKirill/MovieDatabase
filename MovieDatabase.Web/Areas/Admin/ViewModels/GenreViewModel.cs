using MovieDatabase.Core.Entities.Catalog;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Web.Areas.Admin.ViewModels
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(Genre.NameLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(Genre.DescriptionLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Description { get; set; }
    }
}
