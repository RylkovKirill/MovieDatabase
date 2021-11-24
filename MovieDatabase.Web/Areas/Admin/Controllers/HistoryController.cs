using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using System;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    public class HistoryController : BaseAdminController
    {
        public HistoryController(IUnitOfWork unit) : base(unit) { }

        [Route("[controller]/[action]")]
        public IActionResult MoviesHistory()
        {
            return View(Unit.MovieHistoryRepository.All());
        }

        [Route("[controller]/[action]")]
        public IActionResult ReviewsHistory()
        {
            return View(Unit.ReviewHistoryRepository.All());
        }

        [Route("[controller]/[action]/{id:guid}")]
        public IActionResult MovieHistoryDetails(Guid id)
        {
            var movieHistory = Unit.MovieHistoryRepository.Find(id);
            if (movieHistory == null)
            {
                return NotFound();
            }

            return View(movieHistory);
        }

        [Route("[controller]/[action]/{id:guid}")]
        public IActionResult ReviewHistoryDetails(Guid id)
        {
            var reviewHistory = Unit.ReviewHistoryRepository.Find(id);
            if (reviewHistory == null)
            {
                return NotFound();
            }

            return View(reviewHistory);
        }
    }
}
