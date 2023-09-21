using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Sustain.Entities;

namespace Sustain.Models
{

    public class CreateSchoolDto
    {
        [Required(ErrorMessage = "School name is required")]
        [MaxLength(100)]
        public string? SchoolName { get; set; }
        [Required(ErrorMessage = "School location is required")]
        [MaxLength(100)]
        public string? SchoolLocation { get; set; }
        [Required(ErrorMessage = "School Type must be set")]
        public int? SchoolTypeId { get; set; }
        // public ICollection<Meter>? Meters { get; set; } = null;

    }
}