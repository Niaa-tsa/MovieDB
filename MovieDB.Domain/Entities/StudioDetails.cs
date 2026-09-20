using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Domain.Entities
{
    public class StudioDetails
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; } = null!;

        public int StudioId { get; set; }
        public Studio Studio { get; set; } = null!;
    }
}
