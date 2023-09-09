using Sustain.Entities;

namespace Sustain.Services
{
    public interface IContactRepository
    {
        Task<Contact?> GetContactByIdAsync(int ContactId);

        Task<(IEnumerable<Contact>, PaginationMetadata)> GetContacts(string? name, string? searchQuery, int pageNumber, int pageSize);

        Task<bool> SaveChangesAsync();

        Task<Contact> CreateContactAsync(Contact contact);

        void DeleteContact(Contact contact);
    }
}
