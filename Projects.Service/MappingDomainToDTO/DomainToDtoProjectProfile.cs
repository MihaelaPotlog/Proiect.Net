using System.Linq;
using AutoMapper;
using Projects.Domain.Models;
using Projects.Service.DTOs;

namespace Projects.Service.Mapping
{
    public class DomainToDtoProjectProfile: Profile
    {
        public DomainToDtoProjectProfile()
        {
            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.Technologies, opt =>
                    opt.MapFrom(src =>
                        src.ProjectTechnologies.Select(elem =>  elem.Technologie.Name)))
                .ForMember(dest => dest.CollaboratorsId, opt =>
                    opt.MapFrom(src => src.ProjectUsers.Select(elem => elem.UserId)));
        }
    }
}