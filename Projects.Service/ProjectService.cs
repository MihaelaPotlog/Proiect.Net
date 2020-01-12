﻿using Projects.Domain.Models;
using Projects.Service.DTOs;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Projects.Domain.Repositories;
using Projects.Service.Common;
using Projects.Service.Validators;
using System.Collections.Generic;
using Projects.Service.Constants;
using Projects.Service.DTOs.RequestsDTOs;
using System;

namespace Projects.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateInvitation(CreateInvitationDto request, CancellationToken cancellationToken)
        {
            Project selectedProject = await _projectRepository.Get(request.ProjectId, cancellationToken);
            if (selectedProject == null)
                return ErrorMessages.InvalidProjectId;

            CreateInvitationDtoValidator dtoValidator = new CreateInvitationDtoValidator(_projectRepository);
            var validationResult = await dtoValidator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
                return validationResult.ToString();

            Invitation newInvitation = Invitation.CreateInvitation(request.ProjectId, selectedProject, request.CollaboratorId, request.OwnerId, request.InvitationType);
            await _projectRepository.AddInvitation(newInvitation, cancellationToken);

            return "success";
        }

        public async Task<List<Invitation>> GetUserInvitations(GetUserInvitationDto request, CancellationToken cancellationToken)
        {
            var invitations = await _projectRepository.GetaAllInvitationsAsUser(request.UserId, cancellationToken);

            if (invitations.Count == 0)
                return null;
            else
            {
                return invitations;
            }
        }

        public async Task<List<Invitation>> GetOwnerRequests(GetOwnerRequestDto request, CancellationToken cancellationToken)
        {
            var requests = await _projectRepository.GetaAllInvitationsAsOwner(request.OwnerId, cancellationToken);

            if (requests.Count == 0)
                return null;
            else
            {
                return requests;
            }
        }
        public async Task<ProjectDto> CreateProject(CreateProjectDto request, CancellationToken cancellationToken)
        {
            Project createdProject = Project.CreateProject(request.OwnerId, request.Name, request.Description, request.State);
            await _projectRepository.Add(createdProject, cancellationToken);

            ProjectUser projectUserLink = ProjectUser.CreateProjectUser(createdProject.Id, request.OwnerId, createdProject);
            await _projectRepository.AddProjectUser(projectUserLink, cancellationToken);

            foreach (string technologyName in request.Technologies)
            {
                Technology technology = await _projectRepository.GetTechnologyByName(technologyName);
                await _projectRepository.AddProjectTechnology(createdProject, technology, cancellationToken);
            }

            return _mapper.Map<ProjectDto>(createdProject);
        }

        public async Task<List<ProjectDto>> GetProjects(CancellationToken cancellationToken)
        {
            List<Project> projects = await _projectRepository.GetAll(cancellationToken);

            return _mapper.Map<List<ProjectDto>>(projects);
        }

        public async Task<string> HandleInvitation(HandleInvitationDto request, CancellationToken cancellationToken)
        {
            Project selectedProject = await _projectRepository.Get(request.ProjectId, cancellationToken);
            if (selectedProject == null)
                return ErrorMessages.NonexistentProject;

            Invitation toBeRemovedInvitation =
                await _projectRepository.GetInvitation(request.ProjectId, request.CollaboratorId, request.OwnerId);
            if (toBeRemovedInvitation == null)
                return ErrorMessages.NonexistentInvitation;

            await _projectRepository.RemoveInvitation(toBeRemovedInvitation);
            if (request.Accepted == 1)
            {
                ProjectUser projectUserLink =
                    ProjectUser.CreateProjectUser(request.ProjectId, request.CollaboratorId, selectedProject);
                await _projectRepository.AddProjectUser(projectUserLink, cancellationToken);

            }

            return SuccessMessages.Success;
        }

        public async Task<ProjectDto> GetProject(Guid id, CancellationToken cancellationToken)
        {
            Project currentProject = await  _projectRepository.GetProjectInfo(id, cancellationToken);
            return _mapper.Map<ProjectDto>(currentProject);
        }
    }
}

