using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Projects.Domain.Models;
using Projects.Service.DTOs;
using Projects.Service.DTOs.RequestsDTOs;

namespace Projects.Service
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateProject(CreateProjectDto request, CancellationToken cancellationToken);
        Task<List<ProjectDto>> GetProjects(CancellationToken cancellationToken);

        Task<string> CreateInvitation(CreateInvitationDto request, CancellationToken cancellationToken);

        Task<List<Invitation>> GetUserInvitations(GetUserInvitationDto request, CancellationToken cancellationToken);

        Task<List<Invitation>> GetOwnerRequests(GetOwnerRequestDto request, CancellationToken cancellationToken);
        Task<string> HandleInvitation(HandleInvitationDto request, CancellationToken cancellationToken);
        Task<ProjectDto> GetProject(Guid id, CancellationToken cancellationToken);
    }
}
