using System;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Web.Areas.Admin.ViewModels;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    public class DistributorController : BaseAdminController
    {
        public DistributorController(IUnitOfWork unit) : base(unit) { }

        [Route("[controller]")]
        public IActionResult List()
        {
            return View(Unit.DistributorRepository.All());
        }

        [Route("[controller]/[action]/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            var distributor = Unit.DistributorRepository.Find(id);
            if (distributor == null)
            {
                return NotFound();
            }

            return View(distributor);
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DistributorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var distributor = new Distributor()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    DateFounded = model.DateFounded
                };

                Unit.DistributorRepository.Add(distributor);
                Unit.Commit();

                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var distributor = Unit.DistributorRepository.Find(id);
            if (distributor == null)
            {
                return NotFound();
            }

            var model = new DistributorViewModel
            {
                Id = distributor.Id,
                Name = distributor.Name,
                Description = distributor.Description,
                DateFounded = distributor.DateFounded
            };

            return View(model);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DistributorViewModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var distributor = Unit.DistributorRepository.Find(id);
            if (distributor == null)
            {
                return NotFound();
            }

            distributor.Name = model.Name;
            distributor.Description = model.Description;
            distributor.DateFounded = model.DateFounded;

            Unit.Commit();

            return RedirectToAction(nameof(List));
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var distributor = Unit.DistributorRepository.Find(id);
            if (distributor == null)
            {
                return NotFound();
            }

            return View(distributor);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var distributor = Unit.DistributorRepository.Find(id);

            Unit.DistributorRepository.Remove(distributor);
            Unit.Commit();

            return RedirectToAction(nameof(List));
        }
    }
}
