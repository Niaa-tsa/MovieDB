using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MovieDB.Infrastructure.Data;
using MovieDB.Infrastructure.Repositories;
using MovieDB.Infrastructure.Services;
using MovieDB.Service.DTOs;
using MovieDB.Service.Interfaces;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection");

var services = new ServiceCollection();

services.AddDbContext<MovieDbContext>(opt =>
    opt.UseSqlServer(connectionString));

services.AddScoped<IMovieRepository, MovieRepository>();
services.AddScoped<IMovieService, MovieService>();

var provider = services.BuildServiceProvider();

var service = provider.GetRequiredService<IMovieService>();

await service.AddAsync(new CreateMovieDTO
{
    Title = "Interstellar",
    ReleaseYear = 2014,
    StudioId = 1
});

var movies = await service.GetAllAsync();

foreach (var m in movies)
{
    Console.WriteLine($"{m.Title} - {m.StudioName}");
}