using MovieDatabase.Common.Paging;
using MovieDatabase.Core.Entities.Catalog;
using System;
using System.Linq.Expressions;

namespace MovieDatabase.Core.Repositories.Catalog
{
    public interface IMovieRepository : IRepository<Movie, Guid>
    {
        PagedList<Movie> GetPagedList(PageInfo pageInfo, Expression<Func<Movie, bool>> expression = null);
    }
}
