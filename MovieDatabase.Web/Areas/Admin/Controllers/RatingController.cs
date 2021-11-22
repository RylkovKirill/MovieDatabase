using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    public class RatingController : BaseAdminController
    {
        public RatingController(IUnitOfWork unit) : base(unit) { }

        [Route("[controller]")]
        public IActionResult List()
        {
            return View(Unit.RatingRepository.All());
        }

        [Route("[controller]/[action]/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            var rating = Unit.RatingRepository.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rating model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();

                Unit.RatingRepository.Add(model);
                Unit.Commit();

                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var rating = Unit.RatingRepository.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Rating model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rating = Unit.RatingRepository.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            rating.Name = model.Name;
            rating.Description = model.Description;

            Unit.Commit();

            return RedirectToAction(nameof(List));
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var rating = Unit.RatingRepository.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var rating = Unit.RatingRepository.Find(id);

            Unit.RatingRepository.Remove(rating);
            Unit.Commit();

            return RedirectToAction(nameof(List));
        }
    }
}
