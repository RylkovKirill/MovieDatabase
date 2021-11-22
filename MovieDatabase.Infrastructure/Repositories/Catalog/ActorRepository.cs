using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Core.Repositories.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieDatabase.Infrastructure.Repositories.Catalog
{
    public sealed class ActorRepository : Repository<Actor, Guid>, IActorRepository
    {
        public ActorRepository(ApplicationDbContext context) : base(context) { }

        protected override IEnumerable<Actor> InternalFilter(Expression<Func<Actor, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected override IQueryable<Actor> MakeInclusions()
        {
            return DbSet.Include(x => x.Movies);
        }
    }
}
