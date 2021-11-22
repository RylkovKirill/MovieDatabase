using Microsoft.AspNetCore.Identity;
using MovieDatabase.Core.Entities.Catalog;
using System;
using System.Collections.Generic;

namespace MovieDatabase.Core.Entities.Membership
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Review> Reviews { get; set; }
    }
}
