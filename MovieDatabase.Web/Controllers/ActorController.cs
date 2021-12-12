using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using System;


namespace MovieDatabase.Web.Controllers
{
    public class ActorController : BaseController
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
    }
}
