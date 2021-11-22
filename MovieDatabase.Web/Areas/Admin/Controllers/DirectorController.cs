using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Web.Areas.Admin.ViewModels;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    public class DirectorController : BaseAdminController
    {
        public DirectorController(IUnitOfWork unit) : base(unit) { }

        [Route("[controller]")]
        public IActionResult List()
        {
            return View(Unit.DirectorRepository.All());
        }

        [Route("[controller]/[action]/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            var director = Unit.DirectorRepository.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DirectorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var director = new Director()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth
                };

                Unit.DirectorRepository.Add(director);
                Unit.Commit();

                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var director = Unit.DirectorRepository.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            var model = new DirectorViewModel
            {
                FirstName = director.FirstName,
                LastName = director.LastName,
                DateOfBirth = director.DateOfBirth
            };

            return View(model);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DirectorViewModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var director = Unit.DirectorRepository.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            director.FirstName = model.FirstName;
            director.LastName = model.LastName;
            director.DateOfBirth = model.DateOfBirth;

            Unit.Commit();

            return RedirectToAction(nameof(List));
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var director = Unit.DirectorRepository.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var director = Unit.DirectorRepository.Find(id);

            Unit.DirectorRepository.Remove(director);
            Unit.Commit();

            return RedirectToAction(nameof(List));
        }
    }
}
