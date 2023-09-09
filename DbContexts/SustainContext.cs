using Sustain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Sustain.DbContexts
{
    public class SustainContext : DbContext
    {
        public SustainContext(DbContextOptions<SustainContext> options)
            : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; } = null!;    
        public DbSet<Meter> Meter { get; set; } = null!;
        public DbSet<MeterReading> MeterReading { get; set; } = null!;
        public DbSet<MeterType> MeterType { get; set; } = null!;
        public DbSet<School> School { get; set; } = null!;
    }
}