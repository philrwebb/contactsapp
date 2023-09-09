using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Sustain.Entities;

namespace Sustain.Models
{
    public class CreateMeterTypeDto
    {
        public int MeterTypeId { get; set; }
        public string TypeShortDescription { get; set; } = "";
        public string? TypeLongDescription { get; set; } = "";
        public string? TypeUnitOfMeasure { get; set; } 
    }
}