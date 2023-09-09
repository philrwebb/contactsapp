using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustain.Entities
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        [MaxLength(255)]
        public string? FirstName { get; set; }
        [MaxLength(255)]
        public string? LastName { get; set; }
        [MaxLength(255)]
        public string? EmailAddress { get; set; }
        [MaxLength(100)]
        public string? Phone { get; set; }
    }
}