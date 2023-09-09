using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Sustain.Entities;

namespace Sustain.Models
{

    public class CreateSchoolDto
    {
        [MaxLength(100)]
        public string? SchoolName { get; set; }
        [MaxLength(100)]
        public string? SchoolLocation { get; set; }
        [MaxLength(4)]
        public string? SchoolType { get; set; }
        // public ICollection<Meter>? Meters { get; set; } = null;
        
    }
}