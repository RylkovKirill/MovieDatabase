using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Repositories.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieDatabase.Infrastructure.Repositories.Catalog
{
    public sealed class GenreRepository : Repository<Genre, Guid>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context) { }

        protected override IEnumerable<Genre> InternalFilter(Expression<Func<Genre, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected override IQueryable<Genre> MakeInclusions()
        {
            return DbSet.Include(x => x.Movies);
        }
    }
}
