using System.ComponentModel.DataAnnotations;
namespace Contacts.Models
{
    public class ContactCreateDto
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(255, ErrorMessage = "First name cannot be longer than 255 characters")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(255, ErrorMessage = "Last name cannot be longer than 255 characters")]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(255, ErrorMessage = "Email address cannot be longer than 255 characters")]
        public string? EmailAddress { get; set; }
        [MaxLength(100, ErrorMessage = "Phone number cannot be longer than 100 characters")]
        public string? Phone { get; set; }
    }
}