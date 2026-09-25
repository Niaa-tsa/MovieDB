using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Service.DTOs
{
    public class UpdateMovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public int StudioId { get; set; }
    }
}
