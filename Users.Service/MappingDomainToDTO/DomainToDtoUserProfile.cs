using System.Linq;
using AutoMapper;
using Users.Domain.Models;
using Users.Service.DTOs;

namespace Users.Service.MappingDomainToDTO
{
    class DomainToDtoUserProfile:Profile
    {
        public DomainToDtoUserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.KnownTechnologies, opt =>
                    opt.MapFrom(src => src.UserTechnologies.Select(elem => elem.Technology.Name)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        }
    }
}
