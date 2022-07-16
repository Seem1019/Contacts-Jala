using AutoMapper;
using Contacts.Core.DTOs;
using Contacts.Core.Entities;

namespace Contacts.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Security, SecurityDto>().ReverseMap();

        }
    }
}
