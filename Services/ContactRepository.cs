using Contacts.DbContexts;
using Contacts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _context;
        private readonly ILogger<ContactRepository> _logger;
        public ContactRepository(ContactContext context, ILogger<ContactRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Contact?> GetContactByIdAsync(int ContactId)
        {
            return await _context.Contact.FindAsync(ContactId);
        }
        public async Task<(IEnumerable<Contact>, PaginationMetadata)> GetContacts(
            string? name, string? searchQuery, int pageNumber, int pageSize
        )
        {
            var collection = _context.Contact as IQueryable<Contact>;
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.LastName!.Contains(name));
            }
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(c => c.LastName!.Contains(searchQuery) || (c.FirstName != null && c.FirstName.Contains(searchQuery)));
            }
            var totalItemCount = await collection.CountAsync();

            var PaginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection.OrderBy (c => c.LastName)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
            return (collectionToReturn, PaginationMetadata);
        }
        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            await _context.Contact.AddAsync(contact);
            return contact;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        void IContactRepository.DeleteContact(Contact contact)
        {
            #pragma warning disable CA2253
            _logger.LogDebug("Deleting contact {0} {1} {2}", contact.ContactId, contact.FirstName, contact.LastName);
            #pragma warning restore CA2253
            _context.Contact.Remove(contact);
        }
    }
}