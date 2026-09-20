using MovieDB.Service.DTOs;
using MovieDB.Service.Interfaces;
using MovieDB.Domain.Entities;

namespace MovieDB.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;

        public MovieService(IMovieRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MovieDTO>> GetAllAsync()
        {
            var movies = await _repo.GetAllAsync();

            return movies.Select(m => new MovieDTO
            {
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
                StudioName = m.Studio.Name
            }).ToList();
        }

        public async Task<MovieDTO> GetByIdAsync(int id)
        {
            var movie = await _repo.GetByIdAsync(id)
                ?? throw new Exception("Movie not found");

            return new MovieDTO
            {
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                StudioName = movie.Studio.Name
            };
        }

        public async Task AddAsync(CreateMovieDTO dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                ReleaseYear = dto.ReleaseYear,
                StudioId = dto.StudioId
            };

            await _repo.AddAsync(movie);
        }
    }
}