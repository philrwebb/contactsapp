using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Sustain.Entities
{
    public abstract class ReferenceBase : TimeLimitedPersistableBase
    {
        [MaxLength(50)]
        public string? typeShortDescription { get; set; }
        [MaxLength(150)]
        public string? typeLongDescription { get; set; }
        public string? typeCode { get; set; }
    }
}