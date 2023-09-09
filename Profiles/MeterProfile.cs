using AutoMapper;
using Sustain.Models;
using Sustain.Entities;

namespace Sustain.Profiles
{
    public class MeterProfile : Profile
    {
        public MeterProfile()
        {
            CreateMap<Entities.Meter, Models.MeterDto>();
            CreateMap<Models.CreateMeterDto, Entities.Meter>();
            CreateMap<Models.CreateSchoolDto, Entities.School>();
            CreateMap<Entities.School,Models.SchoolDto>();
            // CreateMap<Models.ContactUpdateDto, Entities.Contact>();
            // CreateMap<Entities.Contact, Models.ContactUpdateDto>();
        }
    }
}