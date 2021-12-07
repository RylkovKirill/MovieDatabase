using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Web.Areas.Admin.ViewModels;
using MovieDatabase.Web.Services;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    public class MovieController : BaseAdminController
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IFileService _fileService;

        public MovieController(
            IUnitOfWork unit,
            IWebHostEnvironment environment,
            IFileService fileService) : base(unit)
        {
            _environment = environment;
            _fileService = fileService;
        }

        [Route("")]
        [Route("[controller]")]
        public IActionResult List()
        {
            return View(Unit.MovieRepository.All());
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

        [HttpGet("[controller]/[action]")]
        public IActionResult Create()
        {
            ViewData["Ratings"] = new SelectList(Unit.RatingRepository.All(), "Id", "Name");
            ViewData["Directors"] = new SelectList(Unit.DirectorRepository.All(), "Id", "FirstName");
            ViewData["Distributors"] = new SelectList(Unit.DistributorRepository.All(), "Id", "Name");

            return View();
        }

        [HttpPost("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieViewModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Country = model.Country,
                    Language = model.Language,
                    Description = model.Description,
                    Budget = model.Budget,
                    BoxOffice = model.BoxOffice,
                    Runtime = model.Runtime,
                    DateOfRelease = model.DateOfRelease,
                    RatingId = model.RatingId,
                    DirectorId = model.DirectorId,
                    DistributorId = model.DistributorId,
                };

                if (file != null)
                {
                    var fileName = movie.Id.ToString() + Path.GetExtension(file.FileName);

                    var path = Path.Combine(_environment.WebRootPath, "Files/Images/Movies", fileName);
                    _fileService.Save(file, path);

                    movie.ImagePath = fileName;
                }

                Unit.MovieRepository.Add(movie);
                Unit.Commit();

                return RedirectToAction(nameof(List));
            }

            ViewData["Ratings"] = new SelectList(Unit.RatingRepository.All(), "Id", "Name");
            ViewData["Directors"] = new SelectList(Unit.DirectorRepository.All(), "Id", "FirstName");
            ViewData["Distributors"] = new SelectList(Unit.DistributorRepository.All(), "Id", "Name");

            return View(model);
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            var model = new MovieViewModel
            {
                Name = movie.Name,
                Country = movie.Country,
                Language = movie.Language,
                Description = movie.Description,
                ImagePath = movie.ImagePath,
                Budget = movie.Budget,
                BoxOffice = movie.BoxOffice,
                Runtime = movie.Runtime,
                DateOfRelease = movie.DateOfRelease,
                RatingId = movie.RatingId,
                DirectorId = movie.DirectorId,
                DistributorId = movie.DistributorId,
            };

            ViewData["Ratings"] = new SelectList(Unit.RatingRepository.All(), "Id", "Name");
            ViewData["Directors"] = new SelectList(Unit.DirectorRepository.All(), "Id", "FirstName");
            ViewData["Distributors"] = new SelectList(Unit.DistributorRepository.All(), "Id", "Name");

            return View(model);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MovieViewModel model, Guid id)
        {

            if (!ModelState.IsValid)
            {
                ViewData["Ratings"] = new SelectList(Unit.RatingRepository.All(), "Id", "Name");
                ViewData["Directors"] = new SelectList(Unit.DirectorRepository.All(), "Id", "FirstName");
                ViewData["Distributors"] = new SelectList(Unit.DistributorRepository.All(), "Id", "Name");

                return View(model);
            }

            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Name = movie.Name;
            movie.Country = movie.Country;
            movie.Language = movie.Language;
            movie.Description = movie.Description;
            movie.ImagePath = movie.ImagePath;
            movie.Budget = movie.Budget;
            movie.BoxOffice = movie.BoxOffice;
            movie.Runtime = movie.Runtime;
            movie.DateOfRelease = movie.DateOfRelease;
            movie.RatingId = movie.RatingId;
            movie.DirectorId = movie.DirectorId;
            movie.DistributorId = movie.DistributorId;

            Unit.Commit();

            return RedirectToAction(nameof(List));

        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var movie = Unit.MovieRepository.Find(id);

            Unit.MovieRepository.Remove(movie);
            Unit.Commit();

            return RedirectToAction(nameof(List));
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Genres(Guid id)
        {
            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewData["Genres"] = new SelectList(Unit.GenreRepository.All().Except(movie.Genres), "Id", "Name");

            return View(movie);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        public IActionResult AddGenre(Guid id, Guid genreId)
        {
            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            var genre = Unit.GenreRepository.Find(genreId);
            if (genre == null)
            {
                return NotFound();
            }

            movie.Genres.Add(genre);
            Unit.Commit();

            return RedirectToAction(nameof(Genres), new { id });
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        public IActionResult RemoveGenre(Guid id, Guid genreId)
        {
            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            var genre = Unit.GenreRepository.Find(genreId);
            if (genre == null)
            {
                return NotFound();
            }

            movie.Genres.Remove(genre);
            Unit.Commit();

            return RedirectToAction(nameof(Genres), new { id });
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Actors(Guid id)
        {
            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewData["Actors"] = new SelectList(Unit.ActorRepository.All().Except(movie.Actors), "Id", "FullName");

            return View(movie);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        public IActionResult AddActor(Guid id, Guid actorId)
        {
            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            var actor = Unit.ActorRepository.Find(actorId);
            if (actor == null)
            {
                return NotFound();
            }

            movie.Actors.Add(actor);
            Unit.Commit();

            return RedirectToAction(nameof(Actors), new { id });
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        public IActionResult RemovActor(Guid id, Guid actorId)
        {
            var movie = Unit.MovieRepository.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            var actor = Unit.ActorRepository.Find(actorId);
            if (actor == null)
            {
                return NotFound();
            }

            movie.Actors.Remove(actor);
            Unit.Commit();

            return RedirectToAction(nameof(Actors), new { id });
        }
    }
}
