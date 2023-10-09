using Sustain.DbContexts;
using Sustain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Sustain.Services;

public class MeterRepository : IMeterRepository
{
    private readonly SustainContext _context;
    private readonly ILogger<MeterRepository> _logger;


    public MeterRepository(SustainContext context, ILogger<MeterRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<Meter> CreateMeterAsync(Meter meter)
    {
        await _context.Meter.AddAsync(meter);
        return meter;
    }

    public async Task<(IEnumerable<Meter>, PaginationMetadata)> GetMetersForSchoolAsync(
        int schoolId,string? name, string? searchQuery, int pageNumber, int pageSize
        )
    {
        var collection = _context.Meter
            .Include(m => m.MeterType)
            .Include(m => m.MeterReadings)
            .AsQueryable();
        collection = collection.Where((meter) => meter.SchoolId == schoolId);
        var totalItemCount = await collection.CountAsync();
        var PaginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
        var collectionToReturn = await collection.OrderBy(m => m.MeterName)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
        return (collectionToReturn, PaginationMetadata);
    }
}