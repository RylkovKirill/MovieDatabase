using MovieDatabase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MovieDatabase.Core.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : Entity<TKey>
    {
        TEntity Find(TKey id);
        TEntity Find(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> All();
        IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> expression);

        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
