using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Sustain.Entities
{
    public class MeterReading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeterReadingId { get; set; }
        public DateTime ReadingDatetime { get; set; }
        public double ReadingValue { get; set; }
        [ForeignKey("Meter")]
        public int MeterId { get; set; }
        public Meter meter { get; set; } = null!;
    }
}