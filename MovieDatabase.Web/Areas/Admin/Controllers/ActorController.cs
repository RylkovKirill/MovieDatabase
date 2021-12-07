using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Web.Areas.Admin.ViewModels;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    public class ActorController : BaseAdminController
    {
        public ActorController(IUnitOfWork unit) : base(unit) { }

        [Route("[controller]")]
        public IActionResult List()
        {
            return View(Unit.ActorRepository.All());
        }

        [Route("[controller]/[action]/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            var actor = Unit.ActorRepository.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActorViewModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var actor = new Actor()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Country = model.Country,
                    DateOfBirth = model.DateOfBirth,
                    Biogaphy = model.Biogaphy
                };

                if (file != null)
                {
                    using var binaryReader = new BinaryReader(file.OpenReadStream());
                    actor.Avatar = binaryReader.ReadBytes((int)file.Length);
                }

                Unit.ActorRepository.Add(actor);
                Unit.Commit();

                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var actor = Unit.ActorRepository.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            var model = new ActorViewModel
            {
                Id = actor.Id,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                DateOfBirth = actor.DateOfBirth,
                Country = actor.Country,
                Biogaphy = actor.Biogaphy,
                Avatar = actor.Avatar
            };

            return View(model);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ActorViewModel model, IFormFile file, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var actor = Unit.ActorRepository.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            actor.FirstName = model.FirstName;
            actor.LastName = model.LastName;
            actor.DateOfBirth = model.DateOfBirth;
            actor.Country = model.Country;
            actor.Biogaphy = model.Biogaphy;

            if (file != null)
            {
                using var binaryReader = new BinaryReader(file.OpenReadStream());
                actor.Avatar = binaryReader.ReadBytes((int)file.Length);
            }

            Unit.Commit();

            return RedirectToAction(nameof(List));
        }

        [HttpGet("[controller]/[action]/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var actor = Unit.ActorRepository.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        [HttpPost("[controller]/[action]/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var actor = Unit.ActorRepository.Find(id);

            Unit.ActorRepository.Remove(actor);
            Unit.Commit();

            return RedirectToAction(nameof(List));
        }
    }
}
