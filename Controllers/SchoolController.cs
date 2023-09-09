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
}