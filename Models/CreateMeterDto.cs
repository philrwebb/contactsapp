using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Sustain.Entities;

namespace Sustain.Models
{
    public class CreateMeterDto
    {
        [Required(ErrorMessage = "Meter name is required")]
        [MaxLength(255)]
        public string? MeterName { get; set; }
        [MaxLength(255)]
        public string? MeterDescription { get; set; }
        public int? MeterTypeId { get; set; }
        public int? SchoolId { get; set; }
        // public ICollection<MeterReading>? MeterReadings { get; set; } = null;
    }
}