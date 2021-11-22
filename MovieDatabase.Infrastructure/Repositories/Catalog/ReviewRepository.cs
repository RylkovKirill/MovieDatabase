using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Repositories.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieDatabase.Infrastructure.Repositories.Catalog
{
    internal sealed class ReviewRepository : Repository<Review, Guid>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context) { }

        protected override IEnumerable<Review> InternalFilter(Expression<Func<Review, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected override IQueryable<Review> MakeInclusions()
        {
            return DbSet.Include(r => r.User)
                        .Include(r => r.Movie);
        }
    }
}
