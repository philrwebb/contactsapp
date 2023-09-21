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

        public async Task<(IEnumerable<School>, PaginationMetadata)> GetSchools(
            string? name, string? searchQuery, int pageNumber, int pageSize
        )
        {
            var collection = _context.School as IQueryable<School>;
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(s => s.SchoolName!.Contains(name));
            }
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(s => s.SchoolName!.Contains(searchQuery) || (s.SchoolName != null && s.SchoolName.Contains(searchQuery)));
            }
            var totalItemCount = await collection.CountAsync();

            var PaginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy (s => s.SchoolName)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
            return (collectionToReturn, PaginationMetadata);
        }

        public async Task<School?> GetSchoolByIdAsync(int SchoolId)
        {
            return await _context.School.FindAsync(SchoolId);
        }

        public async Task<IEnumerable<SchoolType>> GetSchoolTypes()
        {
            var collection = _context.SchoolType as IQueryable<SchoolType>;
            var collectionToReturn = await collection.ToListAsync();
            return collectionToReturn;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}