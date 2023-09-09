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

}
