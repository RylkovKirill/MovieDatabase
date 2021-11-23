using Microsoft.EntityFrameworkCore;
using MovieDatabase.Common.Paging;
using MovieDatabase.Core.Entities.History;
using MovieDatabase.Core.Repositories.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infrastructure.Repositories.History
{
    public sealed class MovieHistoryRepository : Repository<MovieHistory, Guid>, IMovieHistoryRepository
    {
        public MovieHistoryRepository(ApplicationDbContext context) : base(context) { }

        protected override IEnumerable<MovieHistory> InternalFilter(Expression<Func<MovieHistory, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected override IQueryable<MovieHistory> MakeInclusions()
        {
            return DbSet.Include(m => m.Rating)
                        .Include(m => m.Director)
                        .Include(m => m.Distributor);
        }
    }
}
