using MovieDatabase.Core.Entities.Catalog;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Web.Areas.Admin.ViewModels
{
    public class ActorViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(Actor.FirstNameLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(Actor.LastNameLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(Actor.CountryLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
