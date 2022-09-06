using Contacts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.DbContexts
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; } = null!;    
    }
}