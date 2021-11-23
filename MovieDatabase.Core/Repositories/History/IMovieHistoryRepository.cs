using MovieDatabase.Core.Entities.History;
using System;

namespace MovieDatabase.Core.Repositories.History
{
    public interface IMovieHistoryRepository : IRepository<MovieHistory, Guid> { }
}
