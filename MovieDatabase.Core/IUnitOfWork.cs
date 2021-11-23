using MovieDatabase.Core.Repositories.Catalog;
using MovieDatabase.Core.Repositories.History;
using System;


namespace MovieDatabase.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IActorRepository ActorRepository { get; }
        IDirectorRepository DirectorRepository { get; }
        IDistributorRepository DistributorRepository { get; }
        IGenreRepository GenreRepository { get; }
        IMovieRepository MovieRepository { get; }
        IRatingRepository RatingRepository { get; }
        IReviewRepository ReviewRepository { get; }

        IMovieHistoryRepository MovieHistoryRepository { get; }
        IReviewHistoryRepository ReviewHistoryRepository { get; }

        void Commit();
    }
}
