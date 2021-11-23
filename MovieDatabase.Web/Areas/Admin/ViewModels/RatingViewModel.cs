using MovieDatabase.Core.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Web.Areas.Admin.ViewModels
{
    public class RatingViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(Rating.NameLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(Rating.DescriptionLength, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Description { get; set; }
    }
}
