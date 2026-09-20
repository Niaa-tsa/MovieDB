using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Service.DTOs
{
    public class CreateMovieDTO
    {
        public string Title { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public int StudioId { get; set; }
    }
}