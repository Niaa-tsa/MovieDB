using Microsoft.EntityFrameworkCore;
using MovieDB.Domain.Entities;
using MovieDB.Infrastructure.Data;
using MovieDB.Service.Interfaces;

namespace MovieDB.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
            => await _context.Movies.Include(m => m.Studio).ToListAsync();

        public async Task<Movie?> GetByIdAsync(int id)
            => await _context.Movies.Include(m => m.Studio)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                throw new Exception("Movie not found");

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}