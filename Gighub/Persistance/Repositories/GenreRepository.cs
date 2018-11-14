using Gighub.Core.Models;
using Gighub.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Gighub.Persistance.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}