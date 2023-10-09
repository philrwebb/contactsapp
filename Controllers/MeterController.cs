using System.Text.Json;
using AutoMapper;
using Sustain.Entities;
using Sustain.Models;
using Sustain.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Sustain.Controllers;

[Route("api/[controller]")]
[ApiController]

public class MetersController : ControllerBase
{
    private readonly IMeterRepository _meterRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<MetersController> _logger;

    const int maxPageSize = 20;
    public MetersController(
        IMeterRepository meterRepository,
        IMapper mapper,
        ILogger<MetersController> logger
    )
    {
        _meterRepository = meterRepository;
        _mapper = mapper;
        _logger = logger;
    }
    [HttpPost]
    public async Task<ActionResult<MeterDto>> CreateMeterAsync(
        CreateMeterDto meterCreateDto
    )
    {
        var meter = _mapper.Map<Meter>(meterCreateDto);
        await _meterRepository.CreateMeterAsync(meter);
        if (await _meterRepository.SaveChangesAsync())
        {
            return Ok(_mapper.Map<MeterDto>(meter));
        }
        return BadRequest("Could not create contact");

    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MeterDto>>> GetMetersForSchool(int schoolid, string? name, string? searchQuery, int pageNumber = 1, int pageSize = 5)
    {
        if (pageSize > maxPageSize)
        {
            return BadRequest($"Maximum page size is {maxPageSize}");
        }
        var (meters, PaginationMetadata) = await _meterRepository.GetMetersForSchoolAsync(schoolid, name, searchQuery, pageNumber, pageSize);
        Response
    .Headers
    .Add("X-Pagination",
    JsonSerializer.Serialize(PaginationMetadata));

        return Ok(_mapper.Map<IEnumerable<MeterDto>>(meters));
    }
}