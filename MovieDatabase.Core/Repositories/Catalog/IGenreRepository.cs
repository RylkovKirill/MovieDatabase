using MovieDatabase.Core.Entities.Catalog;
using System;

namespace MovieDatabase.Core.Repositories.Catalog
{
    public interface IGenreRepository : IRepository<Genre, Guid> { }
}
