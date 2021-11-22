using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Repositories.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieDatabase.Infrastructure.Repositories.Catalog
{
    public sealed class DistributorRepository : Repository<Distributor, Guid>, IDistributorRepository
    {
        public DistributorRepository(ApplicationDbContext context) : base(context) { }

        protected override IEnumerable<Distributor> InternalFilter(Expression<Func<Distributor, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected override IQueryable<Distributor> MakeInclusions()
        {
            return DbSet.Include(x => x.Movies);
        }
    }
}
