using MovieDatabase.Core.Entities.History;
using System;

namespace MovieDatabase.Core.Repositories.History
{
    public interface IReviewHistoryRepository : IRepository<ReviewHistory, Guid> { }
}
