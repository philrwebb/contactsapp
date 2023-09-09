using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Sustain.Entities
{

    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolId { get; set; }
        [MaxLength(100)]
        public string? SchoolName { get; set; }
        [MaxLength(100)]
        public string? SchoolLocation { get; set; }
        [MaxLength(4)]
        public string? SchoolType { get; set; }
        [ForeignKey("SchoolId")]
        public ICollection<Meter>? Meters { get; set; } = null;
    }
}