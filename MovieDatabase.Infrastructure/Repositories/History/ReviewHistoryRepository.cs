using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities.History;
using MovieDatabase.Core.Repositories.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieDatabase.Infrastructure.Repositories.History
{
    public sealed class ReviewHistoryRepository : Repository<ReviewHistory, Guid>, IReviewHistoryRepository
    {
        public ReviewHistoryRepository(ApplicationDbContext context) : base(context) { }

        protected override IEnumerable<ReviewHistory> InternalFilter(Expression<Func<ReviewHistory, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected override IQueryable<ReviewHistory> MakeInclusions()
        {
            return DbSet.Include(r => r.User)
                        .Include(r => r.Movie);
        }
    }
}
