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

        public async Task<ICollection<Movie>> SearchMoviesByStudioAsync(
          int year, string studioName, int minimumActorCount)
        {
            return await _context.Movies
                .Include(m => m.Studio)
                .Include(m => m.Actors)
                .Where(m =>
                    m.ReleaseYear >= year &&
                    m.Studio.Name == studioName &&
                    m.Actors.Count >= minimumActorCount)
                .OrderByDescending(m => m.ReleaseYear)
                .ThenBy(m => m.Title)
                .ToListAsync();
        }

        public async Task<ICollection<Movie>> SearchMoviesByCountryAsync(
            string countryName, int minimumYear, int maximumActorCount)
        {
            return await _context.Movies
                .Include(m => m.Studio)
                    .ThenInclude(s => s.Country)
                .Include(m => m.Actors)
                .Where(m =>
                    m.Studio.Country.Name == countryName &&
                    m.ReleaseYear >= minimumYear &&
                    m.Actors.Count <= maximumActorCount)
                .OrderBy(m => m.Actors.Count)
                .ThenByDescending(m => m.ReleaseYear)
                .ThenBy(m => m.Title)
                .ToListAsync();
        }

        public async Task<ICollection<Movie>> SearchMoviesAdvancedAsync(
            int fromYear, int toYear, string countryName, string titleText, int minimumActorCount)
        {
            return await _context.Movies
                .Include(m => m.Studio)
                    .ThenInclude(s => s.Country)
                .Include(m => m.Actors)
                .Where(m =>
                    m.ReleaseYear >= fromYear &&
                    m.ReleaseYear <= toYear &&
                    m.Studio.Country.Name == countryName &&
                    m.Title.Contains(titleText) &&
                    m.Actors.Count >= minimumActorCount)
                .OrderByDescending(m => m.Actors.Count)
                .ThenByDescending(m => m.ReleaseYear)
                .ThenBy(m => m.Studio.Name)
                .ThenBy(m => m.Title)
                .ToListAsync();
        }
    }
}