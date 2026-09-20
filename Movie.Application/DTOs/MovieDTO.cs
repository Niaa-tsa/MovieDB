using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Service.DTOs
{
    public class MovieDTO
    {
        public string Title { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string StudioName { get; set; } = null!;
    }
}