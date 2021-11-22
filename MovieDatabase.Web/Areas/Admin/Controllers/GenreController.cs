using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    public class GenreController : BaseAdminController
    {
        public GenreController(IUnitOfWork unit) : base(unit) { }

        [Route("[controller]")]
        public IActionResult List()
        {
            return View(Unit.GenreRepository.All());
        }

        [Route("[controller]/[action]/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            var genre = Unit.GenreRepository.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();

                Unit.GenreRepository.Add(model);
                Unit.Commit();

                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var genre = Unit.GenreRepository.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var genre = Unit.GenreRepository.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            genre.Name = model.Name;
            genre.Description = model.Description;

            Unit.Commit();

            return RedirectToAction(nameof(List));
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var genre = Unit.GenreRepository.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var genre = Unit.GenreRepository.Find(id);

            Unit.GenreRepository.Remove(genre);
            Unit.Commit();

            return RedirectToAction(nameof(List));
        }
    }
}
