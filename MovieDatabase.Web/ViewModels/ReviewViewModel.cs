using MovieDatabase.Core.Entities.Catalog;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Web.ViewModels
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Required]
        [Display(Name = "Content")]
        [StringLength(Review.ContentLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Content { get; set; }

        public Guid MovieId { get; set; }
    }
}
