using MovieDatabase.Core.Entities.Catalog;
using System;

namespace MovieDatabase.Core.Repositories.Catalog
{
    public interface IReviewRepository : IRepository<Review, Guid> { }
}
