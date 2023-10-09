using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Sustain.Entities
{
    public abstract class PersistableBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        [MaxLength(50)]
        public string? CreatedBy { get; set; } 
        public DateTime LastModifiedAt { get; set; }
        [MaxLength(50)]
        public string? LastModifiedBy { get; set; }
    public bool active { get; set; }
}
}