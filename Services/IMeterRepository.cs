using Sustain.Entities;

namespace Sustain.Services;

public interface IMeterRepository
{
    // Task<Meter?> GetMeterByIdAsync(int MeterId);

    // Task<(IEnumerable<Meter>, PaginationMetadata)> GetMeters(string? name, string? searchQuery, int pageNumber, int pageSize);

    Task<bool> SaveChangesAsync();

    Task<Meter> CreateMeterAsync(Meter meter);

    Task<IEnumerable<Meter>> GetMetersForSchoolAsync(int schoolId);
}