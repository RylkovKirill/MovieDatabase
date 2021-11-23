using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Web.Areas.Admin.ViewModels;

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
        public IActionResult Create(RatingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rating = new Rating
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description
                };

                Unit.RatingRepository.Add(rating);
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

            var model = new RatingViewModel
            {
                Id = rating.Id,
                Name = rating.Name,
                Description = rating.Description
            };

            return View(model);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RatingViewModel model, Guid id)
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
