using MovieDatabase.Common.Paging;
using MovieDatabase.Core.Entities.Catalog;
using System;

namespace MovieDatabase.Web.ViewModels
{
    public class MovieListViewModel
    {
        public string Filter { get; set; }
        public Guid? GenreId { get; set; }

        public PagedList<Movie> Movies { get; set; }
    }
}
