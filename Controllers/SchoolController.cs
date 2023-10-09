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
public class SchoolController : ControllerBase
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<SchoolController> _logger;

    const int maxPageSize = 20;
    public SchoolController(
        ISchoolRepository schoolRepository,
        IMapper mapper,
        ILogger<SchoolController> logger
    )
    {
        _schoolRepository = schoolRepository;
        _mapper = mapper;
        _logger = logger;
    }
    [HttpPost]
    public async Task<ActionResult<SchoolDto>> CreateSchoolAsync(
        CreateSchoolDto schoolCreateDto
    )
    {
        var school = _mapper.Map<School>(schoolCreateDto);
        await _schoolRepository.CreateSchoolAsync(school);
        if (await _schoolRepository.SaveChangesAsync())
        {
            return Ok(_mapper.Map<SchoolDto>(school));
        }
        return BadRequest("Could not create contact");

    }

    [HttpGet]
    [Route("SchoolTypes")]
    public async Task<ActionResult<IEnumerable<SchoolTypeDto>>>
    GetSchoolTypes()
    {
        var schooltypes = await _schoolRepository.GetSchoolTypes();
        return Ok(_mapper.Map<IEnumerable<SchoolTypeDto>>(schooltypes));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SchoolDto>>>
    GetSchools(
        string? name,
        string? searchQuery,
        int pageNumber = 1,
        int pageSize = 10
    )
    {
        if (pageSize > maxPageSize)
        {
            pageSize = maxPageSize;
        }
        var (schools, PaginationMetadata) =
            await _schoolRepository
                .GetSchools(name, searchQuery, pageNumber, pageSize);

        Response
            .Headers
            .Add("X-Pagination",
            JsonSerializer.Serialize(PaginationMetadata));
            
        return Ok(_mapper.Map<IEnumerable<SchoolDto>>(schools));
    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<SchoolDto>> GetSchoolByIdAsync(int id)
    // {
    //     var school = await _schoolRepository.GetSchoolByIdAsync(id);
    //     if (school == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(_mapper.Map<SchoolDto>(school));
    // }
}