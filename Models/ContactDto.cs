namespace Sustain.Models
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
    }
}