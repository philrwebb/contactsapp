using Sustain.Entities;
namespace Sustain.Models
{
    public class SchoolDto
    {
        public int SchoolId { get; set; }
        public string? SchoolName { get; set; }
        public string? SchoolLocation { get; set; }
        public int SchoolTypeId { get; set; }
        public List<Meter>? Meters { get; set; } = new List<Meter>();
        public SchoolType? SchoolType { get; set; }
    }
}


