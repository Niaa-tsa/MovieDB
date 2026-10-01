using System;
using System.Collections.Generic;
using System.Text;
using MovieDB.Domain.Entities;

namespace MovieDB.Service.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);    
        Task DeleteAsync(int id);
        Task<ICollection<Movie>> SearchMoviesByStudioAsync(int year, string studioName, int minimumActorCount);

        Task<ICollection<Movie>> SearchMoviesByCountryAsync(string countryName, int minimumYear, int maximumActorCount);

        Task<ICollection<Movie>> SearchMoviesAdvancedAsync(int fromYear, int toYear, string countryName, string titleText, int minimumActorCount);
    }
}