﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Projects.Domain.Models;
using Projects.Service.DTOs;

namespace Projects.Service
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateProject(CreateProjectDto request, CancellationToken cancellationToken);
        Task<List<ProjectDto>> GetProjects(CancellationToken cancellationToken);

        Task<string> CreateInvitation(CreateInvitationDto request, CancellationToken cancellationToken);

        Task<List<Invitation>> GetUserInvitations(GetUserInvitationDto request, CancellationToken cancellationToken);

        Task<List<Invitation>> GetOwnerRequests(GetOwnerRequestDto request, CancellationToken cancellationToken);
    }
}
