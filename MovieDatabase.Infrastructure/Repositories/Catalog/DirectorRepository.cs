using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Repositories.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieDatabase.Infrastructure.Repositories.Catalog
{
    public sealed class DirectorRepository : Repository<Director, Guid>, IDirectorRepository
    {
        public DirectorRepository(ApplicationDbContext context) : base(context) { }

        protected override IEnumerable<Director> InternalFilter(Expression<Func<Director, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected override IQueryable<Director> MakeInclusions()
        {
            return DbSet.Include(x => x.Movies);
        }
    }
}
