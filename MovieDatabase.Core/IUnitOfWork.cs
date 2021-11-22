using MovieDatabase.Core.Repositories.Catalog;
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

        void Commit();
    }
}
