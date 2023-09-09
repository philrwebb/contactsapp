using Microsoft.EntityFrameworkCore;
using Sustain.Entities;
using Sustain.DbContexts;

namespace Sustain.Services
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SustainContext _context;
        private readonly ILogger<SchoolRepository> _logger;
        public SchoolRepository(SustainContext context, ILogger<SchoolRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<School> CreateSchoolAsync(School school)
        {
            await _context.School.AddAsync(school);
            return school;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}