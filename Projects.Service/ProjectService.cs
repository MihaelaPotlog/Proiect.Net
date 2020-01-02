using Projects.Domain.Models;
using Projects.Service.DTOs;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Projects.Domain.Repositories;
using Projects.Service.Common;
using Projects.Service.Validators;
using System.Collections.Generic;

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

            Invitation newInvitation = Invitation.CreateInvitation(request.ProjectId, selectedProject, selectedProject.OwnerId, request.ReceiverId);
            await _projectRepository.AddInvitation(newInvitation, cancellationToken);

            return "success";
        }

        public async Task<ProjectDto> CreateProject(CreateProjectDto request, CancellationToken cancellationToken)
        {
            Project createdProject = Project.CreateProject(request.OwnerId,request.Name, request.Description, request.State);
            await _projectRepository.Add(createdProject, cancellationToken);

            ProjectUser  projectUserLink = ProjectUser.CreateProjectUser(createdProject.Id, request.OwnerId, createdProject);
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
    }
}
