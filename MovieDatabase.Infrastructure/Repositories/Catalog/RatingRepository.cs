using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Repositories.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieDatabase.Infrastructure.Repositories.Catalog
{
    public sealed class RatingRepository : Repository<Rating, Guid>, IRatingRepository
    {
        public RatingRepository(ApplicationDbContext context) : base(context) { }

        protected override IEnumerable<Rating> InternalFilter(Expression<Func<Rating, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected override IQueryable<Rating> MakeInclusions()
        {
            return DbSet.Include(r => r.Movies);
        }
    }
}
