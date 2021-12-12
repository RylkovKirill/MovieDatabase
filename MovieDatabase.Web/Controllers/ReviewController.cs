using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Web.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly UserManager<User> _userManager;

        public ReviewController(IUnitOfWork unit, UserManager<User> userManager) : base(unit)
        {
            _userManager = userManager;
        }

        [Route("[controller]")]
        public async Task<IActionResult> ListAsync()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            var reviews = Unit.ReviewRepository.All(r => r.User == user);

            return View(reviews);
        }
    }
}
