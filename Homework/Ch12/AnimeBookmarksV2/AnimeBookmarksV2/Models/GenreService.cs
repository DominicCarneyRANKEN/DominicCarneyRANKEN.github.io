using Microsoft.EntityFrameworkCore;

namespace AnimeBookmarksV2.Models
{
    public class GenreService
    {
        private readonly AnimeDbContext _context;

        public GenreService(AnimeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

    }
}
