using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieDatabase.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApplicationDbContext context) => DbSet = context.Set<TEntity>();

        public TEntity Find(TKey id) => Find(e => e.Id.Equals(id));

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return InternalFind(expression);
        }

        public IEnumerable<TEntity> All() => All(e => true);

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> expression)
        {
            return InternalFilter(expression);
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        protected virtual TEntity InternalFind(Expression<Func<TEntity, bool>> expression)
        {
            return MakeInclusions().SingleOrDefault(expression);
        }

        protected virtual IEnumerable<TEntity> InternalFilter(Expression<Func<TEntity, bool>> expression)
        {
            return MakeInclusions().Where(expression).ToList();
        }

        protected virtual IQueryable<TEntity> MakeInclusions() => DbSet;
    }
}
