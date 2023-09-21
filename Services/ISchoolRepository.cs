using System.Threading.Tasks;
using Sustain.Entities;
namespace Sustain.Services
{

    public interface ISchoolRepository
    {
        Task<bool> SaveChangesAsync();

        Task<School?> GetSchoolByIdAsync(int SchoolId);

        Task<School> CreateSchoolAsync(School school);

        Task<(IEnumerable<School>, PaginationMetadata)> GetSchools(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<IEnumerable<SchoolType>> GetSchoolTypes();

    }
}