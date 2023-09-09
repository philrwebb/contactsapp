using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Sustain.Entities
{

    public class MeterType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeterTypeId { get; set; }
        [MaxLength(255)]
        public string TypeShortDescription { get; set; } = "";
        [MaxLength(50)]
        public string? TypeLongDescription { get; set; } = "";
        [MaxLength(150)]
        public string? TypeUnitOfMeasure { get; set; } 
    }
}