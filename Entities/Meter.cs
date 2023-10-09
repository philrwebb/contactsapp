using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Sustain.Entities
{

    public class Meter : PersistableBase
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public int MeterId { get; set; }
        [MaxLength(255)]
        public string? MeterName { get; set; }
        [MaxLength(255)]
        public string? MeterDescription { get; set; }
        [ForeignKey("MeterType")]
        public int? MeterTypeId { get; set; }
        public string? UtilityAccountNumber { get; set; }

        [ForeignKey("School")]
        public int? SchoolId { get; set; }
        public MeterType? MeterType { get; set; }

        [ForeignKey("MeterId")]
        public ICollection<MeterReading> MeterReadings { get; set; } = new List<MeterReading>();
    }
}