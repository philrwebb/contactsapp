using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Sustain.Entities
{

    public class MeterType : ReferenceBase
    {
        [MaxLength(150)]
        public string? TypeUnitOfMeasure { get; set; } 
    }
}