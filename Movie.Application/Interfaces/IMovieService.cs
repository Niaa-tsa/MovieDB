using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDB.Service.DTOs;

namespace MovieDB.Service.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDTO>> GetAllAsync();
        Task<MovieDTO> GetByIdAsync(int id);
        Task AddAsync(CreateMovieDTO dto);

        Task UpdateAsync(UpdateMovieDTO dto); 
        Task DeleteAsync(int id);
        Task<List<MovieDTO>> SearchByStudioAsync(int year, string studioName, int minActors);
    }
}