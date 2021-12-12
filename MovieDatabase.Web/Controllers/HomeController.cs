using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MovieDatabase.Common.Paging;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Entities.Membership;
using MovieDatabase.Web.Models;
using MovieDatabase.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieDatabase.Web.Controllers
{
    public class HomeController : BaseController
    {
        private const int PerPage = 5;
        private readonly UserManager<User> _userManager;
        RoleManager<Role> _roleManager;

        public HomeController(IUnitOfWork unit, UserManager<User> userManager, RoleManager<Role> roleManager) : base(unit)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Route("")]
        [Route("[controller]")]
        public IActionResult Index(int page = 1, string filter = null, Guid? genreId = null)
        {
            var pageInfo = new PageInfo(page, PerPage);

            var movies = Unit.MovieRepository.GetPagedList(pageInfo, GetPredicate(filter, genreId));

            var model = new MovieListViewModel
            {
                Movies = movies,
                Filter = filter,
                GenreId = genreId
            };

            ViewData["Genres"] = new SelectList(Unit.GenreRepository.All(), "Id", "Name");

            return View(model);
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        private Expression<Func<Movie, bool>> GetPredicate(string filter, Guid? genreId)
        {
            return (filter, genreId) switch
            {
                (null, null) => null,
                (not null, null) => m => m.Name.ToUpper().Contains(filter),
                (null, not null) => m => m.Genres.Contains(Unit.GenreRepository.Find(genreId.Value)),
                _ => m => m.Name.ToUpper().Contains(filter) && m.Genres.Contains(Unit.GenreRepository.Find(genreId.Value))
            };
        }

        [Route("[controller]/[action]")]
        public async Task<IActionResult> Reviews()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            var reviews = Unit.ReviewRepository.All(r => r.User == user);

            return View(reviews);
        }

        [Route("[controller]/[action]/{id:guid}")]
        public async Task<IActionResult> ReviewDetails(Guid id)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            var review = Unit.ReviewRepository.Find(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        [HttpGet("[controller]/[action]/{movieId:guid}")]
        public IActionResult CreateReview(Guid movieId)
        {
            var model = new ReviewViewModel
            {
                MovieId = movieId
            };

            return View(model);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(ReviewViewModel model, Guid id)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var review = new Review()
                {
                    Id = Guid.NewGuid(),
                    Rating = model.Rating,
                    Content = model.Content,
                    UserId = user.Id,
                    MovieId = model.MovieId
                };

                Unit.ReviewRepository.Add(review);
                Unit.Commit();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult EditReview(Guid id)
        {
            var review = Unit.ReviewRepository.Find(id);
            if (review == null)
            {
                return NotFound();
            }

            var model = new ReviewViewModel
            {
                Id = review.Id,
                Rating = review.Rating,
                Content = review.Content,
                MovieId = review.MovieId
            };

            return View(model);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult EditReview(ReviewViewModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var review = Unit.ReviewRepository.Find(id);
            if (review == null)
            {
                return NotFound();
            }

            review.Rating = model.Rating;
            review.Content = model.Content;
            review.DateUpdated = DateTime.Now;

            Unit.Commit();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult DeleteReview(Guid id)
        {
            var review = Unit.ReviewRepository.Find(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteReviewConfirmed(Guid id)
        {
            var review = Unit.ReviewRepository.Find(id);

            Unit.ReviewRepository.Remove(review);
            Unit.Commit();

            return RedirectToAction(nameof(Index));
        }
    }
}
