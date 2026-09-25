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
    }
}