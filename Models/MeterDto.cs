using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Sustain.Entities;

namespace Sustain.Models
{
    public class MeterDto
    {
        public int MeterId { get; set; }
        public string? MeterName { get; set; }
        public string? MeterDescription { get; set; }
        public int MeterTypeId { get; set; }
        public string? UtilityAccountNumber { get; set; }
        public int? SchoolId { get; set; }
        public List<MeterReading> MeterReading { get; set; } = new List<MeterReading>();
    }
}