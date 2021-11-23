using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MovieDatabase.Common.Paging;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;
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

        public HomeController(IUnitOfWork unit) : base(unit) { }

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
    }
}
