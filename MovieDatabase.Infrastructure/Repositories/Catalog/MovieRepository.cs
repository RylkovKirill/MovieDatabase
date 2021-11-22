using Microsoft.EntityFrameworkCore;
using MovieDatabase.Common.Paging;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Repositories.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieDatabase.Infrastructure.Repositories.Catalog
{
    public sealed class MovieRepository : Repository<Movie, Guid>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context) { }

        public PagedList<Movie> GetPagedList(PageInfo pageInfo, Expression<Func<Movie, bool>> expression = null)
        {
                var query = MakeInclusions();
                if (expression != null)
                {
                    query = query.Where(expression);
                }

                var items = query.OrderBy(x => x.Name)
                                 .SelectPage(pageInfo).ToList();
                
                var total = query.Count();

                return new PagedList<Movie>(items, total, pageInfo);
        }

        protected override IEnumerable<Movie> InternalFilter(Expression<Func<Movie, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected override IQueryable<Movie> MakeInclusions()
        {
            return DbSet.Include(m => m.Rating)
                        .Include(m => m.Director)
                        .Include(m => m.Distributor)
                        .Include(m => m.Actors)
                        .Include(m => m.Genres)
                        .Include(m => m.Reviews);
        }
    }
}
