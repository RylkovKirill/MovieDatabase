using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieDatabase.Core;
using MovieDatabase.Core.Repositories.Catalog;
using MovieDatabase.Core.Repositories.History;
using MovieDatabase.Infrastructure.Repositories.Catalog;
using MovieDatabase.Infrastructure.Repositories.History;
using System;

namespace MovieDatabase.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextOptions _options;
        private ApplicationDbContext _context;

        private ActorRepository _actorRepository;
        private DirectorRepository _directorRepository;
        private DistributorRepository _distributorRepository;
        private GenreRepository _genreRepository;
        private MovieRepository _movieRepository;
        private RatingRepository _ratingRepository;
        private ReviewRepository _reviewRepository;
        private MovieHistoryRepository _movieHistoryRepository;
        private ReviewHistoryRepository _reviewHistoryRepository;

        private bool _isDisposed;

        public IActorRepository ActorRepository => _actorRepository ??= new ActorRepository(Context);
        public IDirectorRepository DirectorRepository => _directorRepository ??= new DirectorRepository(Context);
        public IDistributorRepository DistributorRepository => _distributorRepository ??= new DistributorRepository(Context);
        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(Context);
        public IMovieRepository MovieRepository => _movieRepository ??= new MovieRepository(Context);
        public IRatingRepository RatingRepository => _ratingRepository ??= new RatingRepository(Context);
        public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(Context);
        public IMovieHistoryRepository MovieHistoryRepository => _movieHistoryRepository ??= new MovieHistoryRepository(Context);
        public IReviewHistoryRepository ReviewHistoryRepository => _reviewHistoryRepository ??= new ReviewHistoryRepository(Context);

        private ApplicationDbContext Context => _context ??= new ApplicationDbContext(_options);

        public UnitOfWork(IOptions<UnitOfWorkOptions> options) : this(options.Value)
        {
        }

        public UnitOfWork(UnitOfWorkOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(options.ConnectionString, x => x.CommandTimeout(options.CommandTimeout));
            _options = optionsBuilder.Options;
        }

        public void Commit()
        {
            if (_context == null)
            {
                return;
            }

            if (_isDisposed)
            {
                throw new ObjectDisposedException("UnitOfWork");
            }

            Context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context == null)
            {
                return;
            }

            if (!_isDisposed)
            {
                _context.Dispose();
            }

            _isDisposed = true;
        }
    }
}
