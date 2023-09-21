using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Sustain.Models
{

    public class SchoolTypeDto
    {
        public int SchoolTypeId { get; set; }
        [MaxLength(255)]
        public string TypeShortDescription { get; set; } = "";
        [MaxLength(50)]
        public string? TypeLongDescription { get; set; } = "";
    }
}