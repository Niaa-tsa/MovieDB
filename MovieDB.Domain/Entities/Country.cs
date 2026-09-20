using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Studio> Studios { get; set; } = new List<Studio>();
    }
}
