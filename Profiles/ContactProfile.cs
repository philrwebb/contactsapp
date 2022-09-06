using AutoMapper;

namespace Contacts.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Entities.Contact, Models.ContactDto>();
            CreateMap<Models.ContactCreateDto, Entities.Contact>();
            CreateMap<Models.ContactUpdateDto, Entities.Contact>();
            CreateMap<Entities.Contact, Models.ContactUpdateDto>();
        }
    }
}