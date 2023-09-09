using Sustain.Entities;
namespace Sustain.Models
{
    public class SchoolDto
    {
        public int SchoolId { get; set; }
        public string? SchoolName { get; set; }
        public string? SchoolLocation { get; set; }
        public string? SchoolType { get; set; }
        public List<Meter>? Meters { get; set; } = new List<Meter>();
    }
}