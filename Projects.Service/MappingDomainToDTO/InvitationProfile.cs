using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Projects.Domain.Models;
using Projects.Service.DTOs.RequestsDTOs;

namespace Projects.Service.MappingDomainToDTO
{
    public class InvitationProfile:Profile
    {
       public InvitationProfile()
        {
            CreateMap<Invitation, ResponseInvitationDTO>()
                  .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name));
                
            
        }
    }
}
